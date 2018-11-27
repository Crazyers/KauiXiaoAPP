using FastSchool.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastSchool.WebApi.Models
{
    public class ViewModelOrderInfo : ViewModelOrder
    {
        public EnumExpressType EnumExpressType { get; set; }

        /// <summary>
        /// 取货码
        /// </summary>
        public int PickUpCode { get; set; }

        /// <summary>
        /// 取货地址
        /// </summary>
        public string PickUpAddress { get; set; }

        /// <summary>
        /// 配送地址
        /// </summary>
        public string Sendaddress { get; set; }

        /// <summary>
        /// 悬赏金额
        /// </summary>
        public string Ponus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
}
