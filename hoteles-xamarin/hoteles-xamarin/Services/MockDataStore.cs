using hoteles_xamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hoteles_xamarin.Services
{
    public class MockDataStore : IDataStore<Hotel>
    {
        readonly List<Hotel> items;

        public MockDataStore()
        {
            items = new List<Hotel>()
            {
                /*new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }*/
                new Hotel { 
                    Id = Guid.NewGuid().ToString(), 
                    Cedula = "1315767200", 
                    NameCompleto="This is an item description.",
                    Fecha="23/09/1998",
                    NumPersonas="3",
                    TipoHabitacion="Familiar",
                    NumHabitacion="115",
                    Lugar="Portoviejo",
                    PrecioDia="15",
                    DiasEstadia="15",
                    PrecioReserva="245"
                }
            };
        }

        public async Task<bool> AddItemAsync(Hotel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Hotel item)
        {
            var oldItem = items.Where((Hotel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Hotel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Hotel> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Hotel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}