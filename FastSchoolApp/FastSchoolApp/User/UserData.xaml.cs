using FastSchoolApp.Services;
using FastSchoolApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FastSchoolApp.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserData : ContentPage
    {
        public UserData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 提交审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void submitBtn_Clicked(object sender, EventArgs e)
        {
            var shouName = txtShowName.Text;    //用户名
            var name = txtUserName.Text;    //姓名    
            var number = txtUserNumber.Text;
            var phone = txtUserPhone.Text;
            #region 判断的逻辑
            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(number) && string.IsNullOrWhiteSpace(phone))
            {
                await DisplayAlert("提示", "没有修改任何信息！", "确认");
                return;
            }
            var user = new Model.User
            {
                UserName = shouName
            };
            if (!string.IsNullOrWhiteSpace(name))
                user.FullName = name?.Trim();
            if (!string.IsNullOrWhiteSpace(number))
            {
                if (!Regex.IsMatch(number, "[0-9]{8,11}"))
                {
                    await DisplayAlert("错误提示", "请填写正确的学号！", "确定");
                    return;
                }
                user.SchoolNumber = long.Parse(number?.Trim());
            }
            if (!string.IsNullOrWhiteSpace(phone))
            {
                if (!Regex.IsMatch(phone, "[0-9]{11}"))
                {
                    await DisplayAlert("错误提示", "请填写正确的手机号！", "确定");
                    return;
                }
                var b = long.TryParse(phone?.Trim(), out var userPhone);
                user.Phone = userPhone;
            }
            #endregion

            UserService userService = new UserService();
            var result = await userService.EitUserDataAsync(user);
            var str = result ? "成功" : "失败";
            UserDataModel.GetUser = null;
            await DisplayAlert("提示", $"修改{str}！！", "确定");
        }
    }
}