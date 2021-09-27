using BakeryLibraries;
using MetalBandBakery.PriceServicesWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace MetalBandBaket.PriceServicesWebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class PayController : ControllerBase {
        [Route("Pay")]
        [HttpPost]
        public void Pay(ItemPay itemPay) {
            IPayRepository repository = new PayRepository();
            
            repository.Pay(itemPay);
        }
        [Route("ReadPayLog")]
        [HttpGet]
        public string ReadRepositoryOfItems() {
            IPayRepository repository = new PayRepository();
            return repository.ReadRepositoryOfItems();
        }
    }
}