using BakeryLibraries;
using MetalBandBakery.Core.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MetalBandBakey.Infra.Repository {
    public class RestPayService : IPayService {

        public void Pay(double quantity, string payer, string receiver) {
            string apiUrl ="https://localhost:44330/Pay/Pay";
            using(WebClient client = new WebClient()) {
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                ItemPay itemPay = new ItemPay(quantity, payer, receiver);
                string jsonString = JsonConvert.SerializeObject(itemPay);
                client.UploadString($"{apiUrl}", "Post", jsonString);
            }
        }

        public string ReadRepositoryOfItems() {
            string apiUrl = "https://localhost:44330/Pay/ReadPayLog";
            using(WebClient client = new WebClient()) {
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string ret = client.DownloadString($"{apiUrl}");
                return ret;
            }
        }
    }
}