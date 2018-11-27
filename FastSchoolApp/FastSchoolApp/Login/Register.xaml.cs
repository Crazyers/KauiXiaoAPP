using FastSchoolApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FastSchoolApp.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        protected AccountService AccountService { get; }
        public Register()
        {
            InitializeComponent();
            AccountService = new AccountService();
        }

        private async void submitBtn_Clicked(object sender, EventArgs e)
        {
            var phone = userPhone.Text;
            if (string.IsNullOrWhiteSpace(phone))
            {
                await DisplayAlert("错误提示", "手机号不能为空！", "确定");
                return;
            }
            if (!Regex.IsMatch(phone, "[0-9]{11}"))
            {
                await DisplayAlert("错误提示", "请填写正确的手机号！", "确定");
                return;
            }
            var number = userNumber.Text;
            if (!Regex.IsMatch(number, "[0-9]{8,11}"))
            {
                await DisplayAlert("错误提示", "请填写正确的学号！", "确定");
                return;
            }
            var name = userName.Text;
            var pwd = userLastPwd.Text;
            var shouName = userShowName.Text;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(pwd) || string.IsNullOrWhiteSpace(shouName))
            {
                await DisplayAlert("错误提示", "请填写完整的信息！", "确定");
                return;
            }
            var user = new Model.User
            {
                UserName = shouName,
                UserPwd = userLastPwd.Text,
                Phone = long.Parse(phone),
                SchoolNumber = long.Parse(number),
                FullName = name
            };
            var result = await AccountService.RegisterAsync(user);
            var str = result ? "成功" : "失败";
            var b = await DisplayAlert("提示", $"注册{str}\r\n是否跳转登录页", "确定", "取消");
            if (b)
                await Navigation.PopToRootAsync();
        }
    }
}