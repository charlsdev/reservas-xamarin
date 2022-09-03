using hoteles_xamarin.Controllers;
using hoteles_xamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace hoteles_xamarin.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        public HotelControllers hotelCtrl;
        
        private string cedula;
        private string nameCompleto;
        private DateTime fecha;
        private string numPersonas;
        private string tipoHabitacion;
        private string numHabitacion;
        private string lugar;
        private string precioDia;
        private string diasEstadia;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(cedula)
                && !String.IsNullOrWhiteSpace(nameCompleto)
                //&& !String.IsNullOrWhiteSpace(fecha)
                && !String.IsNullOrWhiteSpace(numPersonas)
                && !String.IsNullOrWhiteSpace(tipoHabitacion)
                && !String.IsNullOrWhiteSpace(numHabitacion)
                && !String.IsNullOrWhiteSpace(lugar)
                && !String.IsNullOrWhiteSpace(precioDia)
                && !String.IsNullOrWhiteSpace(diasEstadia);
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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            hotelCtrl = new HotelControllers();

            bool status = await hotelCtrl.SaveReserva(
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
                // This will pop the current page off the navigation stack
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
