using MetalBandBakery.Core.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MetalBandBakey.Infra.Repository {
    public class RestfullPriceService : IPriceService {
        public class ItemData {
            private decimal quantity;

            public ItemData(string itemId, decimal quantity, string name=null) {
                this.itemId = itemId;
                this.quantity = quantity;
                this.name = name;
            }

            public string itemId { get; set; }
            public decimal price { get; set; }
            public string name { get; set; }
        }

        public decimal GetPrice(string itemId) {
            string apiUrl = "https://localhost:44330/prices/GetOne/itemID";
            using(WebClient client = new WebClient()) {
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string json = client.DownloadString($"{apiUrl}/{itemId}");
                var itemPrice = JsonConvert.DeserializeObject<ItemData>(json);
                return itemPrice.price;
            }
        }
        public IEnumerable<ItemData> GetAllItemPrices(string itemId) {
            string apiUrl = "https://localhost:44330/prices/GetAll";
            using(WebClient client = new WebClient()) {
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string json = client.DownloadString($"{apiUrl}/{itemId}");
                var itemIenumerable = JsonConvert.DeserializeObject<IEnumerable<ItemData>>(json);
                return itemIenumerable;
            }
        }
        public void SetPrice(string itemId, decimal quantity) {
            string apiUrl ="https://localhost:44330/prices/SetPrice";
            using(WebClient client = new WebClient()) {
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                ItemData itemPrice = new ItemData(itemId, quantity);
                string jsonString = JsonConvert.SerializeObject(itemPrice);
                client.UploadString($"{apiUrl}", "Post", jsonString);
            }
        }
        public void AddNewItem(string itemId, decimal quantity, string name) {
            string apiUrl ="https://localhost:44330/prices/AddNewItem";
            using(WebClient client = new WebClient()) {
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                ItemData itemPrice = new ItemData(itemId, quantity, name);
                string jsonString = JsonConvert.SerializeObject(itemPrice);
                client.UploadString($"{apiUrl}", "Post", jsonString);
            }
        }
    }
}
