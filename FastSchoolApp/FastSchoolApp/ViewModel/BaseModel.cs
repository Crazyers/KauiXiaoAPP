using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FastSchoolApp.ViewModel
{
    public class BaseModel: BindableObject
    {

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
