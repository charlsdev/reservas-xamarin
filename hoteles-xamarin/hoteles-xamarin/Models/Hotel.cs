using System;

namespace hoteles_xamarin.Models
{
    public class Hotel
    {
        public string Id { get; set; }
        public string Cedula { get; set; }
        public string NameCompleto { get; set; }
        public string Fecha { get; set; }
        public string NumPersonas { get; set; }
        public string TipoHabitacion { get; set; }
        public string NumHabitacion { get; set; }
        public string Lugar { get; set; }
        public string PrecioDia { get; set; }
        public string DiasEstadia { get; set; }
        public string PrecioReserva { get; set; }
    }
}