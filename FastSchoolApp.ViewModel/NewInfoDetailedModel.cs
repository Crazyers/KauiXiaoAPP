using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FastSchoolApp.ViewModel
{
    public class NewInfoDetailedModel : BindableObject
    {

        public BindableProperty BonusProperty = BindableProperty.Create("Bonus",
    typeof(decimal),
    typeof(NewInfoDetailedModel));
        /// <summary>
        /// 悬赏金额
        /// </summary>
        public decimal Bonus
        {
            get { return (decimal)GetValue(BonusProperty); }
            set { SetValue(BonusProperty, value); }
        }

        public BindableProperty ExpressTypeProperty = BindableProperty.Create(
            "ExpressType",
            typeof(ExpressTypeEnum),
            typeof(NewInfoDetailedModel));
        /// <summary>
        /// 快递类型
        /// </summary>
        public ExpressTypeEnum ExpressType
        {
            get { return (ExpressTypeEnum)GetValue(BonusProperty); }
            set { SetValue(BonusProperty, value); }
        }


        public BindableProperty RemarksTypeProperty = BindableProperty.Create(
            "Remarks",
            typeof(string),
            typeof(NewInfoDetailedModel));
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks
        {
            get { return GetValue(RemarksTypeProperty).ToString(); }
            set { SetValue(RemarksTypeProperty, value); }
        }
    }
}
