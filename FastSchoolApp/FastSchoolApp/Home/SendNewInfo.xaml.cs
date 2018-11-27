using FastSchoolApp.Common;
using FastSchoolApp.Model;
using FastSchoolApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FastSchoolApp.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendNewInfo : ContentPage
    {
        protected HomeService HomeService { get; }
        public SendNewInfo()
        {
            InitializeComponent();
            HomeService = new HomeService();
        }

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void sendNewInfo_Clicked(object sender, EventArgs e)
        {
            #region 判断逻辑，不应该再这里判断
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                await DisplayAlert("提示", "姓名不能为空！", "确认");
                return;
            }
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                await DisplayAlert("提示", "取货码不能为空！", "确认");
                return;
            }
            if (!Regex.IsMatch(txtCode.Text, "[0-9]{3,12}"))
            {
                await DisplayAlert("提示", "不是有效的取货码！", "确认");
                return;
            }
            if (string.IsNullOrEmpty(txtGetAddress.Text))
            {
                await DisplayAlert("提示", "取货地点不能为空！", "确认");
                return;
            }
            if (string.IsNullOrEmpty(txtSendAddress.Text))
            {
                await DisplayAlert("提示", "详细地址不能为空！", "确认");
                return;
            }
            var ExpressType = txtExpressTypePicker.SelectedItem.ToString();

            if (string.IsNullOrEmpty(ExpressType))
            {
                await DisplayAlert("提示", "快递类型不能为空！", "确认");
                return;
            }
            var enumKey = Enum.TryParse<ExpressTypeEnum>(ExpressType, out var exType);
            if (!enumKey)
            {
                await DisplayAlert("提示", "请选择正确的快递类型！", "确认");
                return;
            }
            var b = decimal.TryParse(txtMoney.Text, out var result);
            if (string.IsNullOrEmpty(txtMoney.Text) && !b)
            {
                await DisplayAlert("提示", "请填写正确的悬赏金额！", "确认");
                return;
            }
            #endregion

            //数据插入逻辑代码
            var commdity = new Commodity
            {
                Consignee = txtUserName.Text?.Trim(),
                PickUpAddress = txtGetAddress.Text?.Trim(),
                PickUpCode = int.Parse(txtCode.Text?.Trim()),
                Ponus = b ? txtMoney.Text?.Trim() : default,
                Remarks = txtRemarks.Text?.Trim(),
                Sendaddress = txtSendAddress.Text?.Trim(),
                EnumExpressType = exType,
                UserName = AccountHelper.LoginName,
            };
            var key = await HomeService.SendNewInfoAsync(commdity);
            var str = key ? "成功" : "失败";
            var resultKey = await DisplayAlert("提示", $"发布{str}！\r\n是否跳转首页？", "确定", "取消");
            if (!resultKey)
                return;

            //跳转首页
            Application.Current.MainPage = new HomeMasterDetailPage();
        }

        /// <summary>
        /// 选择快递类型时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TxtExpressTypePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            // -1表示没选
            var index = txtExpressTypePicker.SelectedIndex;


            var ExpressType = txtExpressTypePicker.SelectedItem.ToString();
            if (string.IsNullOrEmpty(ExpressType) || index < 0)
            {
                await DisplayAlert("提示", "请选择正确的快递类型！", "确认");
                return;
            }
            var enumKey = Enum.TryParse<ExpressTypeEnum>(ExpressType, out var exType);
            if (!enumKey)
            {
                await DisplayAlert("提示", "请选择正确的快递类型！", "确认");
                return;
            }
        }
    }
}