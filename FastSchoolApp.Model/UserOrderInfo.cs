using System;
using System.Collections.Generic;
using System.Text;

namespace FastSchoolApp.Model
{
    public class UserOrderInfo : UserOrder
    {
        //Code = entiys.Code,
        //        OrderNumber = entiys.OrderNumber,
        //        OrderState = entiys.OrderState,
        //        SendUserName = entiys.SendUser.UserName,
        //        UserName = entiys.User.UserName,

        //        EnumExpressType = entiys.Commodity.EnumExpressType,
        //        PickUpAddress = entiys.Commodity.PickUpAddress,
        //        PickUpCode = entiys.Commodity.PickUpCode,
        //        Ponus = entiys.Commodity.Ponus.ToString("F2"),
        //        Remarks = entiys.Commodity.Remarks,
        //        Sendaddress = entiys.Commodity.Sendaddress

        /// <summary>
        /// 快递类型
        /// </summary>
        public ExpressTypeEnum EnumExpressType { get; set; }

        /// <summary>
        /// 快递领取地址
        /// </summary>
        public string PickUpAddress { get; set; }

        /// <summary>
        /// 配送地址
        /// </summary>
        public string Sendaddress { get; set; }

        /// <summary>
        /// 取货码
        /// </summary>
        public int PickUpCode { get; set; }

        /// <summary>
        /// 赏金
        /// </summary>
        public string Ponus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
}
