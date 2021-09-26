using MetalBandBakery.Core.Services;
using MetalBandBakey.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserAplication.Controllers {
    public class HomeController : Controller {
        private static IPriceService _restPriceService = new RestfullPriceService();
        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult PriceManager() {
            ViewBag.Message = "Here you can Change the prices of the market in real time.";

            return View(_restPriceService.GetAllItemPrices());
        }
    }
}