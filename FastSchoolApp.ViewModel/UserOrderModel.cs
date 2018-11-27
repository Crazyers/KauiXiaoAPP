using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FastSchoolApp.ViewModel
{
    public class UserOrderModel : BindableObject
    {

        public BindableProperty TitleProperty = BindableProperty.Create(
   "Title",
   typeof(string),
   typeof(UserDataModel));
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public BindableProperty OrderNumberProperty = BindableProperty.Create(
"OrderNumber",
typeof(string),
typeof(UserDataModel));
        public string OrderNumber
        {
            get { return (string)GetValue(OrderNumberProperty); }
            set { SetValue(OrderNumberProperty, value); }
        }
    }
}
