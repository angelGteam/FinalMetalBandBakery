using MetalBandBakery.Core.Services;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MetalBandBakey.Infra.Repository {
    public class RestfullPriceService : IPriceService {
        public class ItemPrice {
            public string itemId { get; set; }
            public decimal price { get; set; }
        }

        public decimal GetPrice(string itemId) {
            string apiUrl = "https://localhost:44330/prices";
            using (WebClient client = new WebClient()) {
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string json = client.DownloadString($"{apiUrl}/{itemId}");
                var itemPrice = JsonConvert.DeserializeObject<ItemPrice>(json);
                return itemPrice.price;
            }
        }
        public void SetPrice(string itemId, int quantity) {
            string apiUrl ="https://localhost:44330/prices";
            using(WebClient client = new WebClient()) {
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                ItemPrice itemPrice = new ItemPrice();
                string jsonString = JsonConvert.SerializeObject(itemPrice);
                client.UploadString($"{apiUrl}?itemId={itemId}&quantity={quantity}","Post", jsonString);                
            }
        }
    }
}