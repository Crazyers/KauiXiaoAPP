using FastSchool.Model.Enum;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastSchool.Model
{
    /// <summary>
    /// 发布的商品表
    /// </summary>
    public class Commodity : BaseModel
    {
        public Commodity()
        {
            State = false;
            Ponus = 0.00M;
        }
        private ILazyLoader LazyLoader { get; set; }
        public Commodity(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
            State = false;
            Ponus = 0.00M;
        }

        /// <summary>
        /// 收货人姓名
        /// </summary>
        [StringLength(15), Required]
        public string Consignee { get; set; }

        [Required]
        /// <summary>
        /// 快递类型
        /// </summary>
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
        [StringLength(50), Required]
        public string Sendaddress { get; set; }

        /// <summary>
        /// 悬赏金额
        /// </summary>
        public decimal Ponus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(80)]
        public string Remarks { get; set; }

        /// <summary>
        /// 订单是否已完成,True表示完成了
        /// </summary>
        public bool State { get; set; }


        private User _user;
        [Required]
        /// <summary>
        /// 是谁发出来的
        /// </summary>
        public virtual User User
        {
            //配置导航属性懒加载
            get => LazyLoader.Load(this, ref _user);
            set => _user = value;
        }
    }
}
