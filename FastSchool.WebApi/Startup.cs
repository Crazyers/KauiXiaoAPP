using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FastSchool.BLL;
using FastSchool.Common;
using FastSchool.Interface;
using FastSchool.Model;
using FastSchool.WebApi.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NLog.Extensions.Logging;
using NLog.Web;

namespace FastSchool.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 服务注入
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
            });

            //Microsoft.EntityFrameworkCore.Proxies     UseLazyLoadingProxies()  启用懒加载方法
            //读取配置文件中数据库连接字符串
            services.AddDbContext<FastSchoolDBContext>(option => option.
            UseLazyLoadingProxies().
            UseMySql(Configuration.GetConnectionString("MySqlConnection")));

            //添加jwt验证：
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,//是否验证Issuer
                        ValidateAudience = true,//是否验证Audience
                        ValidateLifetime = true,//是否验证失效时间
                        ValidateIssuerSigningKey = true,//是否验证SecurityKey
                        ValidAudience = "jwttest",//Audience
                        ValidIssuer = "jwttest",//Issuer，这两项和前面签发jwt的设置一致
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))//拿到SecurityKey
                    };
                });

            services.AddMemoryCache();      //使用内置缓存

            services.AddMvc(
                 option =>
                 {
                     option.Filters.Add<ExceptionFilter>();     //错误异常处理的Filter
                     option.Filters.Add<ModelStateFilter>();    //实体验证的Filter
                 }
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region 注册接口开始
            services.AddScoped<DbContext, FastSchoolDBContext>();   //注入DbContext
            services.AddSingleton<ICache, MemoryCache>();           //注入Cach
            services.AddScoped<IAccountBLL, AccountBLL>();
            services.AddScoped<ICommodityBLL, CommodityBLL>();
            services.AddScoped<IUserBLL, UserBLL>();
            services.AddScoped<IOrderBLL, OrderBLL>();
            #endregion 注册接口结束
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 中间件配置
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())    //判断是否为生产/调试模式，不用理他
            {
                app.UseDeveloperExceptionPage();
            }

            //也不知道有什么用，好像是在响应报文里添加一些信息
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            //配置身份验证
            app.UseAuthentication();
            app.UseMvc();

            //添加NLog
            loggerFactory.AddNLog();
            env.ConfigureNLog("nlog.config");   //读取nlog配置文件
        }
    }
}
