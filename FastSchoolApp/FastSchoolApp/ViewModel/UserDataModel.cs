using FastSchoolApp.Common;
using FastSchoolApp.Model;
using FastSchoolApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FastSchoolApp.ViewModel
{
    public class UserDataModel : BindableObject
    {
        public static Model.User GetUser { get; set; }

        public UserDataModel()
        {
            //构造函数不能调用异步方法，，会卡死。。。
            LoadData();
            UserName = GetUser.UserName;
            UserFullName = GetUser.FullName;
            UserNumber = GetUser.SchoolNumber;
            UserPhone = GetUser.Phone;
        }

        public static void LoadData()
        {
            if (GetUser == null)
            {
                UserService userService = new UserService();
                //等待线程执行完成取到结果
                GetUser = userService.GetUserDataAsync().GetAwaiter().GetResult();
            }
        }

        public BindableProperty LoginNameProperty = BindableProperty.Create(
           "LoginName",
           typeof(string),
           typeof(UserDataModel));
        public string LoginName
        {
            get { return AccountHelper.LoginName; }
            set { SetValue(LoginNameProperty, value); }
        }


        public BindableProperty UserNameProperty = BindableProperty.Create(
            "UserName",
            typeof(string),
            typeof(UserDataModel));
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return GetValue(UserNameProperty).ToString(); }
            set { SetValue(UserNameProperty, value); }
        }

        public BindableProperty UserFullNameProperty = BindableProperty.Create(
          "UserFullName",
          typeof(string),
          typeof(UserDataModel));
        /// <summary>
        /// 姓名
        /// </summary>
        public string UserFullName
        {
            get { return GetValue(UserFullNameProperty).ToString(); }
            set { SetValue(UserFullNameProperty, value); }
        }

        public BindableProperty UserNumberProperty = BindableProperty.Create(
        "UserNumber",
        typeof(long),
        typeof(UserDataModel),
        20160300011);
        /// <summary>
        /// 学号
        /// </summary>
        public long UserNumber
        {
            get { return (long)GetValue(UserNumberProperty); }
            set { SetValue(UserNumberProperty, value); }
        }

        public BindableProperty UserPhoneProperty = BindableProperty.Create(
   "UserPhone",
   typeof(long),
   typeof(UserDataModel),
   13888888888);
        /// <summary>
        /// 电话号码
        /// </summary>
        public long UserPhone
        {
            get { return (long)GetValue(UserPhoneProperty); }
            set { SetValue(UserPhoneProperty, value); }
        }
    }
}
