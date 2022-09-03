using hoteles_xamarin.ViewModels;
using hoteles_xamarin.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace hoteles_xamarin
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
