using hoteles_xamarin.Controllers;
using hoteles_xamarin.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace hoteles_xamarin.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailViewModel viewModel;
        public HotelControllers hotelCtrl;

        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }

        private void btnReserva_Clicked(object sender, EventArgs e)
        {
            /*if (viewModel != null)
            {
                if (
                    !string.IsNullOrWhiteSpace(viewModel.Cedula) && 
                    !string.IsNullOrWhiteSpace(viewModel.NameCompleto) && 
                    !string.IsNullOrWhiteSpace(viewModel.NumPersonas) && 
                    !string.IsNullOrWhiteSpace(viewModel.TipoHabitacion) && 
                    !string.IsNullOrWhiteSpace(viewModel.NumHabitacion) && 
                    !string.IsNullOrWhiteSpace(viewModel.Lugar) && 
                    !string.IsNullOrWhiteSpace(viewModel.PrecioDia) && 
                    !string.IsNullOrWhiteSpace(viewModel.DiasEstadia)
                )
                {
                    var opt = await DisplayAlert("Información", "Deseas actualizar la reserva de: " + viewModel.NameCompleto, "Sí", "No");

                    if (opt)
                    {
                        hotelCtrl = new HotelControllers();

                        bool status = await hotelCtrl.UpdateReserva(
                                                            viewModel.ItemId,
                                                            viewModel.Cedula,
                                                            viewModel.NameCompleto,
                                                            viewModel.Fecha,
                                                            viewModel.NumPersonas,
                                                            viewModel.TipoHabitacion,
                                                            viewModel.NumHabitacion,
                                                            viewModel.Lugar,
                                                            viewModel.PrecioDia,
                                                            viewModel.DiasEstadia
                                                        );

                        if (status)
                        {
                            await Shell.Current.GoToAsync("..");
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    await DisplayAlert("Información", "Los campos están vacios." + viewModel.Cedula + " cedula ", "OK");
                }
            }*/
        }
    }
}