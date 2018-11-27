using FastSchoolApp.Model;
using FastSchoolApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FastSchoolApp.ViewModel
{
    public class UserOrderInfoModel : BindableObject
    {
        public static UserOrderInfo UserOrderInfo { get; set; }

        public UserOrderInfoModel()
        {
            if (UserOrderInfo != null)
            {
                EnumExpressType = UserOrderInfo.EnumExpressType;
                OrderNumber = UserOrderInfo.OrderNumber;
                PickUpAddress = UserOrderInfo.PickUpAddress;
                Sendaddress = UserOrderInfo.Sendaddress;
                PickUpCode = UserOrderInfo.PickUpCode;
                Ponus = UserOrderInfo.Ponus;
                Remarks = UserOrderInfo.Remarks;
                UserName = UserOrderInfo.UserName;
                SendUserName = UserOrderInfo.SendUserName;
                OrderState = UserOrderInfo.OrderState.ToString();
                Code = UserOrderInfo.Code;
            }
        }

        #region Base
        public BindableProperty OrderNumberProperty = BindableProperty.Create(
  "OrderNumber",
  typeof(string),
  typeof(UserOrderInfoModel));

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber
        {
            get { return (string)GetValue(OrderNumberProperty); }
            set { SetValue(OrderNumberProperty, value); }
        }


        public BindableProperty OrderStateProperty = BindableProperty.Create(
  "OrderState",
  typeof(string),
  typeof(UserOrderInfoModel));
        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderState
        {
            get
            {
                return GetValue(OrderStateProperty).ToString();
            }
            set { SetValue(OrderStateProperty, value); }
        }


        public BindableProperty SendUserNameProperty = BindableProperty.Create(
  "SendUserName",
  typeof(string),
  typeof(UserOrderInfoModel));
        /// <summary>
        /// 谁发出来的单子
        /// </summary>
        public string SendUserName
        {
            get
            {
                return GetValue(SendUserNameProperty).ToString();
            }
            set { SetValue(SendUserNameProperty, value); }
        }

        public BindableProperty UserNameProperty = BindableProperty.Create(
  "UserName",
  typeof(string),
  typeof(UserOrderInfoModel));
        /// <summary>
        /// 关联的用户,谁接的单子
        /// </summary>
        public string UserName
        {
            get
            {
                return GetValue(UserNameProperty).ToString();
            }
            set { SetValue(UserNameProperty, value); }
        }

        public BindableProperty CodeProperty = BindableProperty.Create(
"Code",
typeof(Guid),
typeof(UserOrderInfoModel), Guid.NewGuid());
        /// <summary>
        /// 关联订单的Code
        /// </summary>
        public Guid Code
        {
            get
            {
                return Guid.Parse(GetValue(CodeProperty).ToString());
            }
            set { SetValue(CodeProperty, value); }
        }
        #endregion

        public BindableProperty EnumExpressTypeProperty = BindableProperty.Create(
"EnumExpressType",
typeof(ExpressTypeEnum),
typeof(UserOrderInfoModel), ExpressTypeEnum.EMS);
        /// <summary>
        /// 快递类型
        /// </summary>
        public ExpressTypeEnum EnumExpressType
        {
            get
            {
                Enum.TryParse<Model.ExpressTypeEnum>(GetValue(EnumExpressTypeProperty).ToString(), out var result);
                return result;
            }
            set { SetValue(EnumExpressTypeProperty, value); }
        }


        public BindableProperty PickUpAddressProperty = BindableProperty.Create(
"PickUpAddress",
typeof(string),
typeof(UserOrderInfoModel));
        /// <summary>
        /// 快递领取地址
        /// </summary>
        public string PickUpAddress
        {
            get { return GetValue(PickUpAddressProperty).ToString(); }
            set { SetValue(PickUpAddressProperty, value); }
        }



        public BindableProperty SendaddressProperty = BindableProperty.Create(
   "Sendaddress",
   typeof(string),
   typeof(UserOrderInfoModel));
        /// <summary>
        /// 配送地址
        /// </summary>
        public string Sendaddress
        {
            get { return GetValue(SendaddressProperty).ToString(); }
            set { SetValue(SendaddressProperty, value); }
        }


        public BindableProperty PickUpCodeProperty = BindableProperty.Create(
   "PickUpCode",
   typeof(int),
   typeof(UserOrderInfoModel), 000000);
        /// <summary>
        /// 取货码
        /// </summary>
        public int PickUpCode
        {
            get { return Convert.ToInt32(GetValue(PickUpCodeProperty)); }
            set { SetValue(PickUpCodeProperty, value); }
        }


        public BindableProperty PonusProperty = BindableProperty.Create(
      "Ponus",
      typeof(string),
      typeof(UserOrderInfoModel));
        /// <summary>
        /// 赏金
        /// </summary>
        public string Ponus
        {
            get { return GetValue(PonusProperty).ToString(); }
            set { SetValue(PonusProperty, value); }
        }


        public BindableProperty RemarksProperty = BindableProperty.Create(
         "Remarks",
         typeof(string),
         typeof(UserOrderInfoModel));
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks
        {
            get { return GetValue(RemarksProperty).ToString(); }
            set { SetValue(RemarksProperty, value); }
        }
    }
}
