using hoteles_xamarin.Models;
using hoteles_xamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace hoteles_xamarin.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Hotel Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}