using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using GTIApp.Model;
using GTIApp.View;
using Xamarin.Forms;

namespace GTIApp.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {

        #region Properties

        private ObservableCollection<PersonModel> _lstPersons = new ObservableCollection<PersonModel>();

        public ObservableCollection<PersonModel> lstPersons
        {
            get
            {
                return _lstPersons;
            }
            set
            {
                _lstPersons = value;
                OnPropertyChanged("lstPersons");
            }
        }

        private PersonModel _currentPerson = new PersonModel();

        public PersonModel currentPerson
        {
            get
            {
                return _currentPerson;
            }
            set
            {
                _currentPerson = value;
                OnPropertyChanged("currentPerson");
            }
        }

        public ICommand AddNewPersonCommand { get; set; }
        public ICommand EnterAddNewPersonCommand { get; set; }

        public ICommand DeletePersonCommand { get; set; }

        public ICommand EnterEditPersonCommand { get; set; }

        #endregion

        #region Singleton
        private static PersonViewModel instance = null;

        private PersonViewModel()
        {
            InitCommands();
            //InitClass();
        }

        public static PersonViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new PersonViewModel();
            }
            return instance;
        }

        public static void DeleteInstance()
        {
            if (instance != null)
            {
                instance = null;
            }
        }
        #endregion

        #region Methods

        private void AddNewPerson()
        {

            if(currentPerson.Id == null)
            {
                currentPerson.Id = lstPersons.Count() + 1;

                lstPersons.Add(currentPerson);
            }
            else
            {
                foreach (var item in lstPersons)
                {
                    if (item.Id == currentPerson.Id)
                    {
                        item.Name = currentPerson.Name;
                        item.LastName = currentPerson.LastName;
                        item.Age = currentPerson.Age;
                    }
                }
            }

            currentPerson = new PersonModel();

            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopAsync();
        }

        private void EnterEditPerson(int Id)
        {
            currentPerson = lstPersons.FirstOrDefault(x => x.Id == Id);

            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new AddPersonView());
        }

        private void DeletePerson(int Id)
        {
            lstPersons = new ObservableCollection<PersonModel>(lstPersons.Where(x => x.Id != Id).ToList());
        }

        public void EnterAddNewPerson()
        {
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new AddPersonView());
        }
        #endregion

        public void InitCommands()
        {
            AddNewPersonCommand = new Command(AddNewPerson);
            EnterAddNewPersonCommand = new Command(EnterAddNewPerson);
            EnterEditPersonCommand = new Command<int>(EnterEditPerson);
            DeletePersonCommand = new Command<int>(DeletePerson);
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
