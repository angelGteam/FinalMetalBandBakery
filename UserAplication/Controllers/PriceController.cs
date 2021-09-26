using MetalBandBakery.Core.Services;
using MetalBandBakey.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserAplication.Controllers {
    public class PriceController : Controller {
        private static IPriceService _restPriceService = new RestfullPriceService();
        public ActionResult ChangeItemPrice(string itemId) {
            ItemPrice item = new ItemPrice { ItemId = itemId, Price = _restPriceService.GetPrice(itemId) };
            return View(item);
        }
        public ActionResult ChangePrice(ItemPrice itemPrice) {
            _restPriceService.SetPrice(itemPrice.ItemId, itemPrice.Price);
            return RedirectToAction("PriceManager", "Home");
        }
    }
}