using BakeryLibraries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MetalBandBakery.PriceServicesWebAPI.Repositories {
    public class PayRepository : IPayRepository {
        public PayRepository() { }

        public void Pay(ItemPay itemPay) {
            string ToJson = JsonConvert.SerializeObject(itemPay);
            File.WriteAllText($@"Repositories\LocalRepositories\localInMemoryPayLog.json", ToJson);
        }
        public string ReadRepositoryOfItems() {
            return File.ReadAllText($@"Repositories\LocalRepositories\localInMemoryPayLog.json");
        }
    }
}