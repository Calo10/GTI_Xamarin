using System;
using System.ComponentModel;

namespace GTIApp.Model
{
    public class PersonModel : INotifyPropertyChanged
    {
        public int? Id { get; set; }

        private string _Name { get; set; }
        public string Name 
        {
            get

            {
                return _Name;
            }
            set

            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _LastName { get; set; }
        public string LastName 
        {
            get

            {
                return _LastName;
            }
            set

            {
                _LastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public int Age { get; set; }
        public string Photo { get; set; }

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
