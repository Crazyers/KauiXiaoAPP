using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FastSchoolApp.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public HomeMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new HomeMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
          
        }

        class HomeMasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<HomeMasterDetailPageMenuItem> MenuItems { get; set; }
            
            public HomeMasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<HomeMasterDetailPageMenuItem>(new[]
                {
                    new HomeMasterDetailPageMenuItem { Id = 0, Title = "Page 1" },
                    new HomeMasterDetailPageMenuItem { Id = 1, Title = "Page 2" },
                    new HomeMasterDetailPageMenuItem { Id = 2, Title = "Page 3" },
                    new HomeMasterDetailPageMenuItem { Id = 3, Title = "Page 4" },
                    new HomeMasterDetailPageMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}