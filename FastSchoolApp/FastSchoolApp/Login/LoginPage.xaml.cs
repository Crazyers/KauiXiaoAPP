using FastSchoolApp.Common;
using FastSchoolApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FastSchoolApp.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private AccountService AccountService { get; }
        public LoginPage()
        {
            InitializeComponent();
            AccountService = new AccountService();
        }

        private async void userLoginBtn_Clicked(object sender, EventArgs e)
        {
            var name = userName.Text;
            var pwd = userPwd.Text;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(pwd))
            {
                await DisplayAlert("错误提示", "用户名或密码不能为空！", "确定");
                return;
            }
            var result = await AccountService.LoginAsync(new Model.User
            {
                UserName = name,
                UserPwd = pwd
            });
            if (result.Equals("error"))
            {
                await DisplayAlert("错误提示", "用户名或密码错误！", "确定");
                return;
            }

            //把收到令牌记录起来,最好持久化。。。
            AccountHelper.LoginKey = $"Bearer {result}";
            AccountHelper.LoginName = name;

            Application.Current.MainPage = new Home.HomeMasterDetailPage();
        }

        private void userRegister_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register(), true);
        }
    }
}