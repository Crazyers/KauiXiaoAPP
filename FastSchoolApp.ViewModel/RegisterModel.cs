using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FastSchoolApp.ViewModel
{
    public class RegisterModel: BindableObject
    {
        public BindableProperty UserNameProperty = BindableProperty.Create("UserName", typeof(string), typeof(RegisterModel));
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string UserNewPwd { get; set; }
        public string UserFullName { get; set; }
        public long UserNumber { get; set; }
        public long UserPhone { get; set; }
    }
}
