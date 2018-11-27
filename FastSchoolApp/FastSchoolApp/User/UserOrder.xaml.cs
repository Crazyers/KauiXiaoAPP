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
    public partial class UserOrder : ContentPage
    {
        private UserService UserService { get; }
        public UserOrder()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            UserService = new UserService();
            InitializeComponent();
            LoadData();
        }

        /// <summary>
        /// 获取数据绑定到listview
        /// </summary>
        async void LoadData()
        {
            var result = await UserService.GetUserOrderAsync();
            var list = new List<UserOrderModel>();
            if (result.Any())
            {
                result.ForEach(value =>
                {
                    list.Add(new UserOrderModel
                    {
                        Code = value.Code,
                        OrderNumber = value.OrderNumber,
                        OrderState = value.OrderState.ToString(),
                        SendUserName = value.SendUserName,
                        UserName = value.UserName,
                    });
                });
            }
            orderList.ItemsSource = list;
        }

        private void orderList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        /// <summary>
        /// 点击跳转详细页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void orderList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null)
                return;
            var model = e.Item as UserOrderModel;
            var code = model.Code;
            await Navigation.PushAsync(new OrderInfo(code));
        }

        /// <summary>
        /// 下拉刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void orderList_Refreshing(object sender, EventArgs e)
        {
            orderList.IsRefreshing = true;
            LoadData();
            await Task.Delay(1000);  //卡线程
            orderList.IsRefreshing = false;
        }
    }
}