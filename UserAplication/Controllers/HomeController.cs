using MetalBandBakery.Core.Domain;
using MetalBandBakery.Core.Services;
using MetalBandBakey.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserAplication.Controllers {
    public class HomeController : Controller {
        private IPriceService _restPriceService = new RestfullPriceService();
        //private IStockService _soapStockService = new SoapStockService();
        private IPayService _restPayService = new RestPayService();
        private static Order _order = new Order();
        public ActionResult Index() {
            return View();
        }

        //public ActionResult StockManager() {
        //    ViewBag.Message = "StockManager";
        //    return View(_soapStockService.CheckCompleteStock());
        //}

        public ActionResult PriceManager() {
            ViewBag.Message = "Here you can Change the prices of the market in real time.";
            return View(_restPriceService.GetAllItemPrices());
        }
        public ActionResult Vending() {
            ViewBag.Message = "Welcome to the vending.";
            return View(_restPriceService.GetAllItemPrices());
        }
        public ActionResult AddToCart(string itemId) {
            int quantity=1;
            OrderLine newOrder = new OrderLine(itemId, quantity);
            _order.AddItems(newOrder);
           
            return Redirect("Vending");
        }
        public ActionResult BuyItemsInCart() {
            foreach(var item in _order.OrderLines) {
                //_soapStockService.ReduceStock(item.ItemId, 1);
            }
            _restPayService.Pay(_order.AmountToPay, "Payer", "Receiver");
            return Redirect("Vending");
        }
    }
}