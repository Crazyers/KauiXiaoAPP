using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FastSchoolApp.ViewModel
{
    public class UserDataModel : BindableObject
    {
        public BindableProperty UserNameProperty = BindableProperty.Create(
            "UserName",
            typeof(string),
            typeof(UserDataModel));
        public string UserName
        {
            get { return GetValue(UserNameProperty).ToString(); }
            set { SetValue(UserNameProperty, value); }
        }

        public BindableProperty UserFullNameProperty = BindableProperty.Create(
          "UserFullName",
          typeof(string),
          typeof(UserDataModel));
        public string UserFullName
        {
            get { return GetValue(UserFullNameProperty).ToString(); }
            set { SetValue(UserFullNameProperty, value); }
        }

        public BindableProperty UserNumberProperty = BindableProperty.Create(
        "UserNumber",
        typeof(long),
        typeof(UserDataModel));
        public long UserNumber
        {
            get { return (long)GetValue(UserNumberProperty); }
            set { SetValue(UserNumberProperty, value); }
        }

        public BindableProperty UserPhoneProperty = BindableProperty.Create(
   "UserPhone",
   typeof(long),
   typeof(UserDataModel));
        public long UserPhone
        {
            get { return (long)GetValue(UserPhoneProperty); }
            set { SetValue(UserPhoneProperty, value); }
        }
    }
}
