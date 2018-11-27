using FastSchool.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastSchool.WebApi.Models
{
    public class ViewModelCommodity : ViewModelBase
    {
        /// <summary>
        /// 收货人姓名
        /// </summary>
        [StringLength(15)]
        public string Consignee { get; set; }

        public EnumExpressType EnumExpressType { get; set; }

        [Required]
        /// <summary>
        /// 取货码
        /// </summary>
        public int PickUpCode { get; set; }

        /// <summary>
        /// 取货地址
        /// </summary>
        [StringLength(50), Required]
        public string PickUpAddress { get; set; }

        /// <summary>
        /// 配送地址
        /// </summary>
        [StringLength(50)]
        public string Sendaddress { get; set; }

        /// <summary>
        /// 悬赏金额
        /// </summary>
        public string Ponus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(80)]
        public string Remarks { get; set; }

        [Required]
        /// <summary>
        /// 关联的用户名
        /// </summary>
        public string UserName { get; set; }
    }
}
