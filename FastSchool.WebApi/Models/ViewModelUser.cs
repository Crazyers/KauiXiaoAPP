using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastSchool.WebApi.Models
{
    public class ViewModelUser : ViewModelBase
    {
        [StringLength(15)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string UserPwd { get; set; }

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
