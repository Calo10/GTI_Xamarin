using System;
using System.Collections.Generic;
using GTIApp.ViewModel;
using Xamarin.Forms;

namespace GTIApp.View
{
    public partial class MapView : ContentPage
    {
        public MapView()
        {
            InitializeComponent();

            BindingContext = new MapViewModel();
        }
    }
}
