using MetalBandBakery.Core.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MetalBandBakey.Infra.Repository {
    public class RestfullPriceService : IPriceService {
        public decimal GetPrice(string itemId) {
            string apiUrl = "https://localhost:44330/prices/GetOne/itemID";
            using(WebClient client = new WebClient()) {
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string json = client.DownloadString($"{apiUrl}/{itemId}");
                var itemPrice = JsonConvert.DeserializeObject<ItemPrice>(json);
                return itemPrice.Price;
            }
        }
        public IEnumerable<ItemPrice> GetAllItemPrices() {
            string apiUrl = "https://localhost:44330/prices/GetAll";
            using(WebClient client = new WebClient()) {
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string json = client.DownloadString($"{apiUrl}");
                var itemIenumerable = JsonConvert.DeserializeObject<IEnumerable<ItemPrice>>(json);
                return itemIenumerable;
            }
        }
        public void SetPrice(string itemId, decimal quantity) {
            string apiUrl ="https://localhost:44330/prices/SetPrice";
            using(WebClient client = new WebClient()) {
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                ItemPrice itemPrice = new ItemPrice(itemId, quantity);
                string jsonString = JsonConvert.SerializeObject(itemPrice);
                client.UploadString($"{apiUrl}", "Post", jsonString);
            }
        }
        public void AddNewItem(string itemId, decimal quantity, string name) {
            string apiUrl ="https://localhost:44330/prices/AddNewItem";
            using(WebClient client = new WebClient()) {
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                ItemPrice itemPrice = new ItemPrice(itemId, quantity, name);
                string jsonString = JsonConvert.SerializeObject(itemPrice);
                client.UploadString($"{apiUrl}", "Post", jsonString);
            }
        }
    }
}