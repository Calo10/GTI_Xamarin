using System;
using System.Collections.Generic;
using GTIApp.ViewModel;
using Xamarin.Forms;

namespace GTIApp.View
{
    public partial class AddPersonView : ContentPage
    {
        public AddPersonView()
        {
            InitializeComponent();

            BindingContext = PersonViewModel.GetInstance();
        }
    }
}
