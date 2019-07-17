using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        #endregion

        #region Methods

        public void EnterAddPerson()
        {
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new LoginView());
        }
        #endregion

        public HomeViewModel()
        {
            lstMenu = MenuModel.GetMenu();
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
