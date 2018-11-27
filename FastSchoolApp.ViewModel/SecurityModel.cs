using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FastSchoolApp.ViewModel
{
    public class SecurityModel : BindableObject
    {
        public BindableProperty OldPwdProperty = BindableProperty.Create("OldPwd", typeof(string), typeof(SecurityModel));
        public string OldPwd { get; set; }
        public string Pwd { get; set; }
        public string PwdNew { get; set; }
    }
}
