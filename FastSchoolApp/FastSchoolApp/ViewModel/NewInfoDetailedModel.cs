using FastSchoolApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FastSchoolApp.ViewModel
{
    public class NewInfoDetailedModel : BindableObject
    {
        public static NewInfoModel NewInfoModel { get; set; }
        public NewInfoDetailedModel()
        {
            if (NewInfoModel == null)
                NewInfoModel = new NewInfoModel();

            PickUpAddress = NewInfoModel.PickUpAddress;
            EnumExpressType = NewInfoModel.EnumExpressType;
            Consignee = NewInfoModel.Consignee;
            PickUpCode = NewInfoModel.PickUpCode;
            Sendaddress = NewInfoModel.Sendaddress;
            Ponus = NewInfoModel.Ponus;
            Remarks = NewInfoModel.Remarks;
            Code = NewInfoModel.Code;
        }

        public BindableProperty PickUpAddressProperty = BindableProperty.Create(
          "PickUpAddress",
          typeof(string),
          typeof(NewInfoModel));
        /// <summary>
        /// 取货地址
        /// </summary>
        public string PickUpAddress
        {
            get
            {
                return GetValue(PickUpAddressProperty).ToString();
            }
            set { SetValue(PickUpAddressProperty, value); }
        }


        public BindableProperty ConsigneeProperty = BindableProperty.Create("Consignee", typeof(string), typeof(NewInfoModel));
        /// <summary>
        /// 姓名
        /// </summary>
        public string Consignee
        {
            get
            {
                return GetValue(ConsigneeProperty).ToString();
            }
            set { SetValue(ConsigneeProperty, value); }
        }


        public BindableProperty EnumExpressTypeProperty = BindableProperty.Create("EnumExpressType", typeof(ExpressTypeEnum), typeof(NewInfoModel), ExpressTypeEnum.EMS);
        /// <summary>
        /// 快递类型
        /// </summary>
        public ExpressTypeEnum EnumExpressType
        {
            get
            {
                Enum.TryParse<ExpressTypeEnum>(GetValue(EnumExpressTypeProperty).ToString(), out var result);
                return result;
            }
            set { SetValue(EnumExpressTypeProperty, value); }
        }

        public BindableProperty PickUpCodeProperty = BindableProperty.Create("PickUpCode", typeof(int), typeof(NewInfoModel), 000000);
        /// <summary>
        /// 取货码
        /// </summary>
        public int PickUpCode
        {
            get
            {
                return Convert.ToInt32(GetValue(PickUpCodeProperty));
            }
            set { SetValue(PickUpCodeProperty, value); }
        }

        public BindableProperty SendaddressProperty = BindableProperty.Create("Sendaddress", typeof(string), typeof(NewInfoModel));
        /// <summary>
        /// 配送地址
        /// </summary>
        public string Sendaddress
        {
            get
            {
                return GetValue(SendaddressProperty).ToString();
            }
            set { SetValue(SendaddressProperty, value); }
        }

        public BindableProperty PonusProperty = BindableProperty.Create("Ponus", typeof(string), typeof(NewInfoModel), "0.00");
        /// <summary>
        /// 悬赏金额
        /// </summary>
        public string Ponus
        {
            get
            {
                return Convert.ToString(GetValue(PonusProperty));
            }
            set { SetValue(PonusProperty, value); }
        }
        
        public BindableProperty RemarksProperty = BindableProperty.Create("Remarks", typeof(string), typeof(NewInfoModel));
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks
        {
            get
            {
                return Convert.ToString(GetValue(RemarksProperty));
            }
            set { SetValue(RemarksProperty, value); }
        }

        public BindableProperty SendCodeProperty = BindableProperty.Create("UserName", typeof(Guid), typeof(NewInfoModel), Guid.Empty);
        /// <summary>
        /// 唯一标识
        /// </summary>
        public Guid Code
        {
            get
            {
                return (Guid)(GetValue(SendCodeProperty));
            }
            set { SetValue(SendCodeProperty, value); }
        }
    }
}
