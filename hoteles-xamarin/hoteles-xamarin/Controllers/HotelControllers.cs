using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using hoteles_xamarin.Models;
using static Xamarin.Essentials.Permissions;

namespace hoteles_xamarin.Controllers
{
    public class HotelControllers
    {
        //string urlAPI = "http://192.168.100.86:4000/api";
        string urlAPI = "https://api-hoteles-xamarin.onrender.com/api";

        public async Task<bool> SaveReserva(
            string ced, string nameCom, DateTime fecha, string numPer, string tipoHab, 
            string numHab, string lugar, string preDia, string diasEst
        )
        {
            Uri url = new Uri(urlAPI);

            Hotel emp = new Hotel
            {
                Cedula = ced,
                NameCompleto = nameCom,
                Fecha = fecha.ToString(),
                NumPersonas = numPer,
                TipoHabitacion = tipoHab,
                NumHabitacion = numHab,
                Lugar = lugar,
                PrecioDia = preDia,
                DiasEstadia = diasEst
            };

            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(emp);
            var contJson = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, contJson);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Hotel>> AllReservas()
        {
            Uri url = new Uri(urlAPI);

            var req = new HttpRequestMessage();
            req.RequestUri = url;
            req.Method = HttpMethod.Get;
            req.Headers.Add("Accept", "application/json");

            var client = new HttpClient();

            HttpResponseMessage res = await client.SendAsync(req);

            if (res.StatusCode == HttpStatusCode.OK)
            {
                string content = await res.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Hotel>>(content);

                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteReserva(string ced)
        {
            string uri = $"{urlAPI}/{ced}";

            var client = new HttpClient();

            var response = await client.DeleteAsync(uri);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Hotel> OneReserva(string ced)
        {
            Uri url = new Uri($"{urlAPI}/{ced}");

            var req = new HttpRequestMessage();
            req.RequestUri = url;
            req.Method = HttpMethod.Get;
            req.Headers.Add("Accept", "application/json");

            var client = new HttpClient();

            HttpResponseMessage res = await client.SendAsync(req);

            if (res.StatusCode == HttpStatusCode.OK)
            {
                string content = await res.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Hotel>(content);

                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateReserva(
            string id, string ced, string nameCom, DateTime fecha, string numPer, 
            string tipoHab, string numHab, string lugar, string preDia, string diasEst
        )
        {
            Uri url = new Uri(urlAPI);

            Hotel emp = new Hotel
            {
                Id = id,
                Cedula = ced,
                NameCompleto = nameCom,
                Fecha = fecha.ToString(),
                NumPersonas = numPer,
                TipoHabitacion = tipoHab,
                NumHabitacion = numHab,
                Lugar = lugar,
                PrecioDia = preDia,
                DiasEstadia = diasEst
            };

            var client = new HttpClient();

            var json = JsonConvert.SerializeObject(emp);
            var contJson = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(url, contJson);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
