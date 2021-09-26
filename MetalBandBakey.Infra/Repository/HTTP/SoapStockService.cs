using MetalBandBakery.Core.Services;
using System.Collections.Generic;

namespace MetalBandBakey.Infra.Repository {
    public class SoapStockService : IStockService {
        public bool CheckStock(string itemId) {
            WCFStockServices.IService _WCFStockServices = new WCFStockServices.ServiceClient();
            return _WCFStockServices.CheckStock(itemId) > 0;
        }

        public void ReduceStock(string itemId, int quantity) {
            WCFStockServices.IService _WCFStockServices = new WCFStockServices.ServiceClient();
            _WCFStockServices.ReduceStock(itemId, quantity);
        }
        public void IncreaseStock(string itemId, int quantity) {
            WCFStockServices.IService _WCFStockServices = new WCFStockServices.ServiceClient();
            _WCFStockServices.IncreaseStock(itemId, quantity);
        }
        public List<ItemStock> CheckCompleteStock() {
            WCFStockServices.IService _WCFStockServices = new WCFStockServices.ServiceClient();
            return _WCFStockServices.CheckCompleteStock();
        }
    }
}