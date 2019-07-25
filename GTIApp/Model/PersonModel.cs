using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GTIApp.Model
{
    public class PersonModel : INotifyPropertyChanged
    {
        #region Properties

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

        #endregion

        public async static Task<ObservableCollection<PersonModel>> GetAllPersons()
        {
            using (HttpClient client = new HttpClient())
            {

                var uri = new Uri("");

                HttpResponseMessage response = await client.GetAsync(uri).ConfigureAwait(false);

                string ans = await response.Content.ReadAsStringAsync();

                var lstPersonas = JsonConvert.DeserializeObject<ObservableCollection<PersonModel>>(ans);

                return lstPersonas;
            }
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
