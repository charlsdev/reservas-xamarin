using hoteles_xamarin.Controllers;
using hoteles_xamarin.Models;
using hoteles_xamarin.ViewModels;
using hoteles_xamarin.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace hoteles_xamarin.Views
{
    public partial class ItemsPage : ContentPage
    {
        public HotelControllers hotelCtrl;

        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private async void deleteReserva_Clicked(object sender, EventArgs e)
        {
            hotelCtrl = new HotelControllers();
            Button param = (Button)sender;
            string id = param.CommandParameter.ToString();

            var opt = await DisplayAlert("Información", "Deseas eliminar el empleado con cédula: " + id, "Sí", "No");

            if (opt)
            {
                bool status = await hotelCtrl.DeleteReserva(id);

                if (status)
                {
                    await DisplayAlert("Información", "Reserva eliminada con éxito.", "OK");

                    OnAppearing();
                }
                else
                {
                    await DisplayAlert("Información", "Reserva no eliminada.", "OK");
                }
            }
            else
            {
                return;
            }
        }
    }
}