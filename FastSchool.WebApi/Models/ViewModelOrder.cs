using FastSchool.Model;
using FastSchool.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastSchool.WebApi.Models
{
    public class ViewModelOrder : ViewModelBase
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public EnumOrderState OrderState { get; set; }

        /// <summary>
        /// 谁发出来的单子
        /// </summary>
        public string SendUserName { get; set; }

        /// <summary>
        /// 关联的用户,谁接的单子
        /// </summary>
        public string UserName { get; set; }
    }
}
