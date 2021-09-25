using MetalBandBakery.Core.Services;
using MetalBandBakey.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserAplication.Controllers {
    public class StockController : Controller {
        private static IStockService _wcfStockService = new InMemoryStockService();
        // GET: Stock
        public ActionResult Stock() {
            return View(_wcfStockService.GetItemDictionary());
        }
        private bool CheckStock(string itemId) {
            return _wcfStockService.CheckStock(itemId);
        }
        public void BuyItem(string itemId) {
            if(CheckStock("M")) {
                _wcfStockService.ReduceStock(itemId);
            }
        }

    }
}