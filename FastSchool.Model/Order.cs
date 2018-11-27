using FastSchool.Model.Enum;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastSchool.Model
{
    /// <summary>
    /// 订单表
    /// </summary>
    public class Order : BaseModel
    {
        public Order()
        {
            OrderNumber = $"{DateTime.Now.ToString("yyyyMMddHHmmssffff")}_{Guid.NewGuid().ToString()}";
        }
        private ILazyLoader LazyLoader { get; set; }
        public Order(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
            OrderNumber = $"{DateTime.Now.ToString("yyyyMMddHHmmssffff")}_{Guid.NewGuid().ToString()}";
        }
        /// <summary>
        /// 订单号
        /// </summary>
        [StringLength(200), Required]
        public string OrderNumber { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        [Required]
        public EnumOrderState OrderState { get; set; }


        private User _sendUser;
        [Required]
        /// <summary>
        /// 谁发出来的单子
        /// </summary>
        public virtual User SendUser
        {
            //配置导航属性懒加载
            get => LazyLoader.Load(this, ref _sendUser);
            set => _sendUser = value;
        }

        private User _user;
        /// <summary>
        /// 关联的用户,谁接的单子
        /// </summary>
        [Required]
        public virtual User User
        {
            //配置懒加载
            get => LazyLoader.Load(this, ref _user);
            set => _user = value;
        }

        private Commodity _commodity;
        [Required]
        /// <summary>
        /// 关联的订单，每个订单只能一个商品
        /// </summary>
        public virtual Commodity Commodity
        {
            //配置懒加载
            get => LazyLoader.Load(this, ref _commodity);
            set => _commodity = value;
        }
    }
}
