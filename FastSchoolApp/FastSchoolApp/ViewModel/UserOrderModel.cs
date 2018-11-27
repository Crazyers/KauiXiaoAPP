using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FastSchoolApp.ViewModel
{
    public class UserOrderModel : BindableObject
    {

        public BindableProperty OrderNumberProperty = BindableProperty.Create(
   "OrderNumber",
   typeof(string),
   typeof(UserOrderModel));

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
  typeof(UserOrderModel));
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
  typeof(UserOrderModel));
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
  typeof(UserOrderModel));
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
typeof(UserOrderModel), Guid.Empty);
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
    }
}
