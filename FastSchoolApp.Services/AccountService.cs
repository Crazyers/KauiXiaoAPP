using FastSchoolApp.Common;
using FastSchoolApp.Model;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace FastSchoolApp.Services
{
    public class AccountService : BaseServices
    {
        /// <summary>
        /// 登录的方法
        /// </summary>
        /// <returns>error代表登录失败</returns>
        public async Task<string> LoginAsync(User user)
        {
            var url = $"{BaseUrl}/Account/Login";
            var jsonData = JsonConvert.SerializeObject(user);
            var result = await HttpHelper.HttpPost(url, jsonData);
            return result;
        }

        /// <summary>
        /// 注册的方法
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RegisterAsync(User user)
        {
            var url = $"{BaseUrl}/Account";
            var jsonData = JsonConvert.SerializeObject(user);
            var result = await HttpHelper.HttpPost(url, jsonData);
            return result.Equals("ok");
        }
    }
}
