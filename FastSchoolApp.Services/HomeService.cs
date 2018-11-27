using FastSchoolApp.Common;
using FastSchoolApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FastSchoolApp.Services
{
    public class HomeService : BaseServices
    {
        /// <summary>
        /// 获取最新发布的信息
        /// </summary>
        /// <returns>List集合</returns>
        public async Task<List<Commodity>> GetNewInfoAsync()
        {
            var url = $"{BaseUrl}/Commodity";
            var resultEntiys = await HttpHelper.HttpWebRequestGetAsync(url, authorization: AccountHelper.LoginKey);
            var resut = JsonConvert.DeserializeObject<List<Commodity>>(resultEntiys);
            return resut;
        }

        /// <summary>
        /// 发布新的商品
        /// </summary>
        /// <returns>true代表成功</returns>
        public async Task<bool> SendNewInfoAsync(Commodity commodity)
        {
            var url = $"{BaseUrl}/Commodity";
            var postData = JsonConvert.SerializeObject(commodity);
            var result = await HttpHelper.HttpPost(url, postData, AccountHelper.LoginKey);
            return result.Equals("ok");
        }

        /// <summary>
        /// 接单方法
        /// </summary>
        /// <param name="code">商品code</param>
        /// <returns></returns>
        public async Task<bool> AffirmOrderAsync(Guid code)
        {
            var url = $"{BaseUrl}/Order/{code}/{AccountHelper.LoginName}";
            var result = await HttpHelper.HttpPost(url, string.Empty, authorization: AccountHelper.LoginKey);
            return result.Equals("ok");
        }
    }
}
