using System;
using System.Collections.Generic;
using GTIApp.ViewModel;
using Xamarin.Forms;

namespace GTIApp.View
{
    public partial class MainPersonView : ContentPage
    {
        public MainPersonView()
        {
            InitializeComponent();

            BindingContext = PersonViewModel.GetInstance();
        }
    }
}
