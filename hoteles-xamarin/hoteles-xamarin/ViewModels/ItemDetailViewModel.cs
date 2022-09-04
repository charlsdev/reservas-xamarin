using hoteles_xamarin.Controllers;
using hoteles_xamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace hoteles_xamarin.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        public HotelControllers hotelCtrl;

        public string Id { get; set; }

        private string id;
        private string cedula;
        private string nameCompleto;
        private DateTime fecha;
        private string numPersonas;
        private string tipoHabitacion;
        private string numHabitacion;
        private string lugar;
        private string precioDia;
        private string diasEstadia;

        public ItemDetailViewModel()
        {
            UpdateCommand = new Command(OnUpdate);
        }

        public Command UpdateCommand { get; }

        public string ItemId
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OneReservaSearch(value);
            }
        }

        public string Cedula
        {
            get => cedula;
            set => SetProperty(ref cedula, value);
        }

        public string NameCompleto
        {
            get => nameCompleto;
            set => SetProperty(ref nameCompleto, value);
        }

        public DateTime Fecha
        {
            get => fecha;
            set => SetProperty(ref fecha, value);
        }

        public string NumPersonas
        {
            get => numPersonas;
            set => SetProperty(ref numPersonas, value);
        }

        public string TipoHabitacion
        {
            get => tipoHabitacion;
            set => SetProperty(ref tipoHabitacion, value);
        }

        public string NumHabitacion
        {
            get => numHabitacion;
            set => SetProperty(ref numHabitacion, value);
        }

        public string Lugar
        {
            get => lugar;
            set => SetProperty(ref lugar, value);
        }

        public string PrecioDia
        {
            get => precioDia;
            set => SetProperty(ref precioDia, value);
        }

        public string DiasEstadia
        {
            get => diasEstadia;
            set => SetProperty(ref diasEstadia, value);
        }

        public async void OneReservaSearch(string itemId)
        {
            try
            {
                hotelCtrl = new HotelControllers();
                Hotel items = await hotelCtrl.OneReserva(itemId);

                Cedula = items.Cedula;
                NameCompleto = items.NameCompleto;
                Fecha = DateTime.Parse(items.Fecha);
                NumPersonas = items.NumPersonas;
                TipoHabitacion = items.TipoHabitacion;
                NumHabitacion = items.NumHabitacion;
                Lugar = items.Lugar;
                PrecioDia = items.PrecioDia;
                DiasEstadia = items.DiasEstadia;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
                await Shell.Current.GoToAsync("..");
            }
        }

        private async void OnUpdate()
        {
            hotelCtrl = new HotelControllers();

            bool status = await hotelCtrl.UpdateReserva(
                                            ItemId,
                                            Cedula,
                                            NameCompleto,
                                            Fecha,
                                            NumPersonas,
                                            TipoHabitacion,
                                            NumHabitacion,
                                            Lugar,
                                            PrecioDia,
                                            DiasEstadia
                                        );

            if (status)
            {
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
