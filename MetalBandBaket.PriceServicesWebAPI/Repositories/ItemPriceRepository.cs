using MetalBandBakery.PriceServicesWebAPI.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MetalBandBakery.PriceServicesWebAPI.Repositories {
    public class ItemPriceRepository : IItemPriceRepository {

        private List<ItemData> _prices;

        public ItemPriceRepository() {
            _prices = new List<ItemData>();
            _prices = JsonConvert.DeserializeObject<List<ItemData>>(ReadRepositoryOfItems());
            SaveChanges();
        }

        public ItemData GetOneItem(string itemId) {
            if(!Exists(itemId))
                return null;
            return _prices.Where(m => m.ItemId == itemId).FirstOrDefault();
        }

        private bool Exists(string itemId) {
            return _prices.Where(m => m.ItemId == itemId) != null;
        }

        public IEnumerable<ItemData> GetAllItems() {
            return _prices;
        }
        
        public void SetPrice(string itemId, decimal price) {
            if(Exists(itemId)) {
                int index = _prices.FindIndex(m => m.ItemId == itemId);
                _prices[index].Price = price;
                SaveChanges();
            }
        }
        
        private void SaveChanges() {
            string ToJson = JsonConvert.SerializeObject(_prices);
            File.WriteAllText($@"Repositories\LocalRepositories\localInMemoryItemData.json", ToJson);
        }
        
        private string ReadRepositoryOfItems() {
            return File.ReadAllText($@"Repositories\LocalRepositories\localInMemoryItemData.json");
        }
        
        public void AddNewItem(string itemID, decimal price, string name) {
            if(!Exists(itemID)) {
                var newItem = new ItemData{ItemId = itemID, Price = price, Name = name};
                _prices.Add(newItem);
                SaveChanges();
            }           
        }
    }
}