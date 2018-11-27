using FastSchoolApp.Home;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FastSchoolApp.ViewModel
{
    public class NewInfoModel : BindableObject
    {
        public NewInfoModel()
        {
            LoadData();

            ItemTappedCommand = new Command(async obj =>
            {
                //var entiy = obj as Commodity;


                var nav = App.Current.MainPage.Navigation;

                //传入拿到的实体
                await nav.PushAsync(new NavigationPage(new NewInfoDetailed()));
            });
        }
        public ICommand ItemTappedCommand { get; private set; }

        void LoadData()
        {
            //获取数据

        }

        public BindableProperty TitleProperty = BindableProperty.Create(
            "Title",
            typeof(string),
            typeof(NewInfoModel));
        public string Title
        {
            get
            {
                return GetValue(TitleProperty).ToString();
            }
            set { SetValue(TitleProperty, value); }
        }

        public BindableProperty DetailedProperty = BindableProperty.Create("Detailed", typeof(string), typeof(NewInfoModel));
        public string Detailed
        {
            get
            {
                return GetValue(DetailedProperty).ToString();
            }
            set { SetValue(DetailedProperty, value); }
        }
    }
}
