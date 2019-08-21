using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
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

        #region Methods
        public async static Task<ObservableCollection<PersonModel>> GetAllPersons()
        {
            using (HttpClient client = new HttpClient())
            {

                var uri = new Uri("http://20710e5a.ngrok.io/api/values");

                HttpResponseMessage response = await client.GetAsync(uri).ConfigureAwait(false);

                string ans = await response.Content.ReadAsStringAsync();

                var lstPersonas = JsonConvert.DeserializeObject<ObservableCollection<PersonModel>>(ans);

                return lstPersonas;
            }
        }

        public async static Task<bool> AddPerson(PersonModel person)
        {
            using (HttpClient client = new HttpClient())
            {
                var uri = new Uri("http://20710e5a.ngrok.io/api/values");

                var json = JsonConvert.SerializeObject(new
                {
                    person.Name,
                    Detail = "",
                    Gender = "",
                    person.Age
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(uri, content).ConfigureAwait(false);
                string ans = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<bool>(ans);
            }

        }

        #endregion

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
