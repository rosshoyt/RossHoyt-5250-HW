using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Cool Necklace", Description="It's ice cold.", Value=2 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Basic Doodad", Description="Nothing special here.", Value=5},
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Advanced Ring", Description="Has a nice ring to it.", Value=1 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Hey Jude - Vinyl Record", Description="A short 45-RPM 7-inch record.",Value=8 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Pink Floyd - The Band", Description="My favorite classic rockers, encased in carbonite.", Value=9},
            };
        }

        public async Task<bool> CreateAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemModel> ReadAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}