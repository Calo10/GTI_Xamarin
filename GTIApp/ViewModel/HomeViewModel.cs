using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using GTIApp.Model;
using GTIApp.View;
using Xamarin.Forms;

namespace GTIApp.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {

        #region Properties

        private ObservableCollection<MenuModel> _lstMenu = new ObservableCollection<MenuModel>();

        public ObservableCollection<MenuModel> lstMenu
        {
            get
            {
                return _lstMenu;
            }
            set
            {
                _lstMenu = value;
                OnPropertyChanged("lstMenu");
            }
        }

        public ICommand EnterMenuOptionCommand { get; set; }
        #endregion

        #region Methods

        public void EnterAddPerson()
        {
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new LoginView());
        }

        public void EnterMenuOption(int Id)
        {
            switch (Id)
            {
                case 1:
                    ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new MainPersonView());
                    break;

                case 2:
                    ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new TabbedPageHomeView());
                    break;

                case 3:
                    ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new MapView());
                    break;

                default:
                    break;
            }

        }
        #endregion

        public HomeViewModel()
        {
            lstMenu = MenuModel.GetMenu();
            EnterMenuOptionCommand = new Command<int>(EnterMenuOption);
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
