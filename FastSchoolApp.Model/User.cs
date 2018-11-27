using System;

namespace FastSchoolApp.Model
{
    public class User : BaseModel
    {
        public string UserName { get; set; }

        public string UserPwd { get; set; }

        public string FullName { get; set; }

        /// <summary>
        /// 学号
        /// </summary>
        public long SchoolNumber { get; set; }


        /// <summary>
        /// 手机号
        /// </summary>
        public long Phone { get; set; }
    }
}
