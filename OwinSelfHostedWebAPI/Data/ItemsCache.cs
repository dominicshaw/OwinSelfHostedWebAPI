using System.Collections.Generic;
using OwinSelfHostedWebAPI.Models;

namespace OwinSelfHostedWebAPI.Data
{
    public class ItemsCache
    {
        private readonly List<Item> _items;

        public ItemsCache()
        {
            _items = new List<Item>
            {
                new Item() {Id = 1, Name = "Item 1"},
                new Item() {Id = 2, Name = "Item 2"},
                new Item() {Id = 3, Name = "Item 3"},
                new Item() {Id = 4, Name = "Item 4"}
            };
        }

        public List<Item> GetAll()
        {
            return _items;
        }

        public void Add(Item item)
        {
            _items.Add(item);
        }

        public void Remove(int id)
        {
            _items.RemoveAll(i => i.Id == id);
        }
    }
}
