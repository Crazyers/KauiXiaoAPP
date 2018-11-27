using FastSchoolApp.Common;
using FastSchoolApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FastSchoolApp.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Security : ContentPage
    {
        private UserService Userservice { get; }
        public Security()
        {
            Userservice = new UserService();
            InitializeComponent();
        }

        /// <summary>
        /// 提交修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void eitPwdBtn_Clicked(object sender, EventArgs e)
        {
            var oldPwd = txtOldPwd.Text;
            var newPwd = txtNewPwd.Text;
            var newLastPwd = txtNewLastPwd.Text;
            if (string.IsNullOrEmpty(oldPwd))
            {
                await DisplayAlert("提示", "原密码不能为空！", "确定");
                return;
            }
            if (!newPwd.Equals(newLastPwd))
            {
                await DisplayAlert("提示", "两次密码不一致！", "确定");
                return;
            }

            //下面是提交修改逻辑...
            var b = await Userservice.EitUserPwdAsync(oldPwd, newPwd);
            if (b)
            {
                await DisplayAlert("提示", "密码修改成功！", "确定");
                AccountHelper.LoginName = null;
                Application.Current.MainPage = new Login.LoginPage();
                return;
            }
            await DisplayAlert("提示", "修改失败！", "确定");
        }
    }
}