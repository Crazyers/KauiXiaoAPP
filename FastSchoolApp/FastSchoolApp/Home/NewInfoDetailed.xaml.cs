using FastSchoolApp.Common;
using FastSchoolApp.Services;
using FastSchoolApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FastSchoolApp.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewInfoDetailed : ContentPage
    {
        public NewInfoDetailed()
        {
            NavigationPage.SetHasNavigationBar(this, false); //隐藏顶栏
            InitializeComponent();
        }

        /// <summary>
        /// 确认下单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Purchase_Clicked(object sender, EventArgs e)
        {
            var model = NewInfoDetailedModel.NewInfoModel;
            AffirmOrderModel.NewInfoModel = model;
            var code = model.Code;
            if (AccountHelper.LoginName.Equals(model.UserName))
            {
                await DisplayAlert("提示", "不允许自己接单", "确定");
                return;
            }
            HomeService service = new HomeService();
            var b = await service.AffirmOrderAsync(code);
            if (!b)
            {
                await DisplayAlert("提示", "下单失败", "确定");
                return;
            }
            await Navigation.PushAsync(new AffirmOrder(), true);
        }
    }
}