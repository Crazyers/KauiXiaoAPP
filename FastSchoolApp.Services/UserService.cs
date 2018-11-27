using FastSchoolApp.Common;
using FastSchoolApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FastSchoolApp.Services
{
    public class UserService : BaseServices
    {
        private static string UserUrl => $"{BaseUrl}/User";

        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns></returns>
        public async Task<User> GetUserDataAsync()
        {
            var entiy = await HttpHelper.HttpWebRequestGetAsync($"{UserUrl}/{AccountHelper.LoginName}", AccountHelper.LoginKey);
            var user = JsonConvert.DeserializeObject<User>(entiy);
            return user;
        }

        /// <summary>
        /// 获取用户订单列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserOrder>> GetUserOrderAsync()
        {
            var url = $"{BaseUrl}/Order/{AccountHelper.LoginName}";
            var entiys = await HttpHelper.HttpWebRequestGetAsync(url, AccountHelper.LoginKey);
            var result = JsonConvert.DeserializeObject<List<UserOrder>>(entiys);
            return result;
        }

        /// <summary>
        /// 获取单个订单
        /// </summary>
        /// <param name="code">订单code</param>
        /// <returns></returns>
        public async Task<UserOrderInfo> GetUserOrderInfoAsync(Guid code)
        {
            var url = $"{BaseUrl}/Order/GetOrderByCode/{code}";
            var entiy = await HttpHelper.HttpWebRequestGetAsync(url, AccountHelper.LoginKey);
            var result = JsonConvert.DeserializeObject<UserOrderInfo>(entiy);
            return result;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns>修改成功返回true</returns>
        public async Task<bool> EitUserPwdAsync(string oldPwd, string newPwd)
        {
            var user = JsonConvert.SerializeObject(new
            {
                UserName = AccountHelper.LoginName,
                UserPwd = newPwd,
            });
            var url = $"{UserUrl}/EitPwd/{oldPwd}";
            var result = await HttpHelper.HttpPut(url, JsonConvert.SerializeObject(new User
            {
                UserName = AccountHelper.LoginName,
                UserPwd = newPwd
            }), AccountHelper.LoginKey);
            return result.Equals("ok");
        }

        /// <summary>
        /// 修改个人资料
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> EitUserDataAsync(User user)
        {
            var url = UserUrl;
            var putData = JsonConvert.SerializeObject(user);
            var result = await HttpHelper.HttpPut(url, putData, AccountHelper.LoginKey);
            return result.Equals("ok");
        }
    }
}
