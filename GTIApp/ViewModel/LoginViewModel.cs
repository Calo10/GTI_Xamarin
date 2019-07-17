using System;
using System.ComponentModel;
using System.Windows.Input;
using GTIApp.View;
using Xamarin.Forms;

namespace GTIApp.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {

        #region Properties

        private string _User { get; set; }

        public string User
        {
            get
            {
                return _User;
            }
            set
            {
                _User = value;
                OnPropertyChanged("User");
            }
        }

        private string _Pass { get; set; }

        public string Pass
        {
            get
            {
                return _Pass;
            }
            set
            {
                _Pass = value;
                OnPropertyChanged("Pass");
            }
        }

        public ICommand LoginCommand { get; set; }

        #endregion

        #region Methods

        public async void Login()
        {
            if (User == "Carlos" && Pass == "123")
            {

                NavigationPage navigation = new NavigationPage(new HomeView());

                App.Current.MainPage = new MasterDetailPage
                {
                    Master = new MenuView(),
                    Detail = navigation
                };

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Info", "Wrong Credentials", "Ok");
            }

        }

        #endregion

        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
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
