using System;
using System.Collections.Generic;
using System.Text;

namespace FastSchoolApp.Model
{
    /// <summary>
    /// 登录的用户信息，持久化
    /// </summary>
    public class AccountUserData
    {
        public string UserName { get; set; }
        public string LoginKey { get; set; }
    }
}
