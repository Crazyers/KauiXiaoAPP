using FastSchoolApp.Services;
using FastSchoolApp.ViewModel;
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
    public partial class OrderInfo : ContentPage
    {
        public OrderInfo()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
        public OrderInfo(Guid commodityCode)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            LoadData(commodityCode);
        }

        /// <summary>
        /// 点击时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="code"></param>
        async void LoadData(Guid code)
        {
            var service = new UserService();
            var model = await service.GetUserOrderInfoAsync(code);
            UserOrderInfoModel.UserOrderInfo = model ?? default;
            new UserOrderInfoModel();
        }
    }
}