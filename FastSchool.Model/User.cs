using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastSchool.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User : BaseModel
    {
        public User()
        {

        }
        private ILazyLoader LazyLoader { get; set; }
        public User(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(15)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string UserPwd { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [StringLength(15)]
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
