using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MetalBandBakery.InventoryWCF.Repositories {
    public class InventoryRepository : IInventoryRepository {
        private List<ItemStock> _stock;

        public InventoryRepository() {
            _stock = new List<ItemStock>();
            _stock = JsonConvert.DeserializeObject<List<ItemStock>>(ReadRepositoryOfItems());
        }

        public ItemStock GetItem(string itemId) {
            if(!Exists(itemId))
                return null;
            return _stock.Where(m => m.ItemId == itemId).FirstOrDefault();
        }

        private bool Exists(string itemId) {
            return _stock.Where(m => m.ItemId == itemId) != null;
        }

        public void SaveChanges() {
            string ToJson = JsonConvert.SerializeObject(_stock);
            File.WriteAllText(@"Repositories\LocalRepositories\localInMemoryItemStock.json", ToJson);
        }
        private string ReadRepositoryOfItems() {
            return File.ReadAllText(@"Repositories\LocalRepositories\localInMemoryItemStock.json");
        }
        public List<ItemStock> CheckCompleteStock() {
            return _stock;
        }
    }
}