using System;
using System.Collections.Generic;
using System.Text;

namespace FastSchoolApp.Model
{
    public class Commodity : BaseModel
    {
        public Commodity()
        {
            State = false;
            Ponus = "0.00";
            Code = Guid.NewGuid();
        }

        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string Consignee { get; set; }

        /// <summary>
        /// 快递类型
        /// </summary>
        public ExpressTypeEnum EnumExpressType { get; set; }

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

        /// <summary>
        /// 订单是否已完成,True表示完成了
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// 是谁发出来的
        /// </summary>
        public string UserName { get; set; }

    }
}
