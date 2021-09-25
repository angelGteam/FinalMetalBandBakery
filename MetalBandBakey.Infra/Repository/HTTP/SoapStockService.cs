using MetalBandBakery.Core.Services;
using System.Collections.Generic;

namespace MetalBandBakey.Infra.Repository {
    public class SoapStockService : IStockService {
        public bool CheckStock(string itemId) {
            WCFStockServices.IService svc = new WCFStockServices.ServiceClient();
            return svc.CheckStock(itemId) > 0;
        }

        public void ReduceStock(string itemId) {
            WCFStockServices.IService svc = new WCFStockServices.ServiceClient();
            svc.ReduceStock(itemId);
        }
        public void IncreaseStock(string itemId, int ammount) {
            WCFStockServices.IService svc = new WCFStockServices.ServiceClient();
            svc.IncreaseStock(itemId, ammount);
        }

        public Dictionary<string, int> GetItemDictionary() {
            throw new System.NotImplementedException();
        }
    }
}