using System;
using System.ComponentModel;
using System.Windows.Input;
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

        public void Login()
        {
            if (User == "Carlos" && Pass == "123")
            {

            }
            else
            {

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
