using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FastSchoolApp.ViewModel
{
    public class SendNewInfoModel : BindableObject
    {
        public BindableProperty ConsigneeNameProperty = BindableProperty.Create("ConsigneeName", typeof(string), typeof(SendNewInfoModel));
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string ConsigneeName
        {
            get { return GetValue(ConsigneeNameProperty).ToString(); }
            set { SetValue(ConsigneeNameProperty, value); }
        }

        public BindableProperty ExpressTypeEnumProperty = BindableProperty.Create("ExpressType", typeof(ExpressTypeEnum), typeof(SendNewInfoModel));
        /// <summary>
        /// 快递类型        最好用枚举
        /// </summary>
        public ExpressTypeEnum ExpressType
        {
            get { return (ExpressTypeEnum)GetValue(ExpressTypeEnumProperty); }
            set { SetValue(ExpressTypeEnumProperty, value); }
        }

        public BindableProperty GetGoodsCodeProperty = BindableProperty.Create("GetGoodsCode", typeof(int), typeof(SendNewInfoModel));
        /// <summary>
        /// 取货码
        /// </summary>
        public int GetGoodsCode {
            get { return (int)GetValue(GetGoodsCodeProperty); }
            set { SetValue(GetGoodsCodeProperty, value); }
        }

        public BindableProperty GetGoodsAddressProperty = BindableProperty.Create("GetGoodsAddress", typeof(string), typeof(SendNewInfoModel));
        /// <summary>
        /// 取货地点
        /// </summary>
        public string GetGoodsAddress {
            get { return (string)GetValue(GetGoodsAddressProperty); }
            set { SetValue(GetGoodsAddressProperty, value); }
        }

        public BindableProperty SendAddressProperty = BindableProperty.Create("SendAddress", typeof(string), typeof(SendNewInfoModel));
        /// <summary>
        /// 收货地址
        /// </summary>
        public string SendAddress
        {
            get { return (string)GetValue(SendAddressProperty); }
            set { SetValue(SendAddressProperty, value); }
        }

        /// <summary>
        /// 悬赏金额
        /// </summary>
        public decimal Bonus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
}
