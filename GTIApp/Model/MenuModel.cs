using System;
using System.Collections.ObjectModel;

namespace GTIApp.Model
{
    public class MenuModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Icon { get; set; }

        public static ObservableCollection<MenuModel> GetMenu()
        {
            ObservableCollection<MenuModel> lstMenu = new ObservableCollection<MenuModel>
            {
                new MenuModel { Id = 1, Name = "Persona", Detail = "", Icon = "http://icons.iconarchive.com/icons/graphicloads/100-flat/256/home-icon.png" },
                new MenuModel { Id = 2, Name = "TabbPage", Detail = "", Icon = "http://icons.iconarchive.com/icons/graphicloads/100-flat/256/home-icon.png" },
                new MenuModel { Id = 3, Name = "Mapa", Detail = "", Icon = "" }
            };

            return lstMenu;
        }
    }
}
