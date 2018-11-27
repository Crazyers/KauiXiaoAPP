using FastSchoolApp.Common;
using FastSchoolApp.Services;
using FastSchoolApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FastSchoolApp.Home
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewInfo : ContentPage
    {
        private HomeService HomeService { get; set; }
        public ObservableCollection<NewInfoModel> NewInfos { get; set; }
        public NewInfo()
        {
            HomeService = new HomeService();
            InitializeComponent();
            LoadNewInfoData();//构造函数不能调用异步方法，，会卡死。。。
        }
        public async Task LoadNewInfoData()
        {
            var result = await HomeService.GetNewInfoAsync();
            NewInfos = new ObservableCollection<NewInfoModel>();
            foreach (var item in result)
            {
                var model = new NewInfoModel
                {
                    Code = item.Code,
                    Consignee = item.Consignee,
                    EnumExpressType = item.EnumExpressType,
                    Ponus = item.Ponus,
                    Remarks = item.Remarks,
                    PickUpCode = item.PickUpCode,
                    Sendaddress = item.Sendaddress,
                    UserName = item.UserName,
                    PickUpAddress = item.PickUpAddress,
                };
                NewInfos.Add(model);
            }
            newInfoList.ItemsSource = NewInfos;
        }
        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void outLogin_Clicked(object sender, EventArgs e)
        {
            AccountHelper.LoginKey = AccountHelper.LoginName = null;
            Application.Current.MainPage = new NavigationPage(new Login.LoginPage());
        }

        private async void newInfoList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null)
                return;

            //执行ItemTappedCommand
            var model = e.Item as NewInfoModel;
            NewInfoDetailedModel.NewInfoModel = model;
            var page = new NewInfoDetailed();
            await Navigation.PushAsync(new NavigationPage(page));
        }

        /// <summary>
        /// 选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newInfoList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        /// <summary>
        /// 下拉刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void newInfoList_Refreshing(object sender, EventArgs e)
        {
            newInfoList.IsRefreshing = boxViewRefreshing.IsVisible = true;
            var listview = sender as ListView;
            await LoadNewInfoData();
            await Task.Delay(1000);  //卡线程
            newInfoList.IsRefreshing = boxViewRefreshing.IsVisible = false;
        }
    }
}