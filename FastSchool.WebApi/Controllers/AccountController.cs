using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FastSchool.BLL;
using FastSchool.Interface;
using FastSchool.Model;
using FastSchool.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FastSchool.WebApi.Controllers
{
    /// <summary>
    /// 登录控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IConfiguration Configuration { get; }
        private IAccountBLL AccountBLL { get; }
        public AccountController(IConfiguration configuration, IAccountBLL accountBLL)
        {
            Configuration = configuration;
            AccountBLL = accountBLL;
        }

        /// <summary>
        /// 登录的Action，发token令牌
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost(nameof(Login))]
        public async Task<string> Login([FromBody]ViewModelUser user)
        {
            //验证用户名和密码
            var entiy = await AccountBLL.GetEntiyAsync<User>(u => u.UserName.Equals(user.UserName) && u.UserPwd.Equals(user.UserPwd));
            if (entiy == null)
            {
                //return new JsonResult(new ResultModel<string> { })
                return "error";
            }
            // push the user’s name into a claim, so we can identify the user later on.
            var claims = new[]
                {
                   new Claim(ClaimTypes.Name, user.UserName)
               };
            //sign the token using a secret key.This secret will be shared between your API and anything that needs to check that the token is legit.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //.NET Core’s JwtSecurityToken class takes on the heavy lifting and actually creates the token.
            /**
             * Claims (Payload)
                Claims 部分包含了一些跟这个 token 有关的重要信息。 JWT 标准规定了一些字段，下面节选一些字段:

                iss: The issuer of the token，token 是给谁的  发送者
                audience: 接收的
                sub: The subject of the token，token 主题
                exp: Expiration Time。 token 过期时间，Unix 时间戳格式
                iat: Issued At。 token 创建时间， Unix 时间戳格式
                jti: JWT ID。针对当前 token 的唯一标识
                除了规定的字段外，可以包含其他任何 JSON 兼容的字段。
             * */
            var token = new JwtSecurityToken(
                issuer: "jwttest",
                audience: "jwttest",
                claims: claims,
                expires: DateTime.Now.AddDays(10),
                signingCredentials: creds);
            var result = new JwtSecurityTokenHandler().WriteToken(token);
            return result;
        }

        [HttpPost]
        /// <summary>
        /// 注册的action
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<IActionResult> Post([FromBody] ViewModelUser user)
        {
            var result = false;
            var entiy = await AccountBLL.GetEntiyAsync<User>(u => u.UserName.Equals(user.UserName));
            if (entiy == null)
            {
                User userEntiy = new User
                {
                    LastEitDateTime = DateTime.Now,
                    FullName = user.FullName,
                    Phone = user.Phone,
                    SchoolNumber = user.SchoolNumber,
                    UserName = user.UserName,
                    UserPwd = user.UserPwd,
                };
                result = await AccountBLL.AddAsync(userEntiy);
            }
            return result ? Content("ok") : Content("error");
        }
    }
}