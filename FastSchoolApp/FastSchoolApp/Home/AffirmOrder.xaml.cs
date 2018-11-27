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
    public partial class AffirmOrder : ContentPage
    {
        public AffirmOrder()
        {
            NavigationPage.SetHasNavigationBar(this, false); //隐藏顶栏
            InitializeComponent();
        }

        /// <summary>
        /// 回到首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goHome_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewInfo());
        }

        /// <summary>
        /// 去到我的订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myOrder_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new User.UserOrder());
        }
    }
}