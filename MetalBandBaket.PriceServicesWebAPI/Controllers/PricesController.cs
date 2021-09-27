using MetalBandBakery.PriceServicesWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace MetalBandBaket.PriceServicesWebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class PricesController : ControllerBase {
        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<ItemPrice> GetAllItems() {
            IItemPriceRepository repository = new ItemPriceRepository();
            return repository.GetAllItems(); ;
        }
        [Route("GetOne/itemId/{itemId}")]
        [HttpGet]
        public ItemPrice GetOneItem(string itemId) {
            IItemPriceRepository repository = new ItemPriceRepository();
            var itemPrice = repository.GetOneItem(itemId);
            return itemPrice;
        }
        [Route("SetPrice")]
        [HttpPost]
        public void ChangePrice(ItemPrice itemPrice) {
            IItemPriceRepository repository = new ItemPriceRepository();
            repository.SetPrice(itemPrice.ItemId, itemPrice.Price);
        }
        [Route("AddNewItem")]
        [HttpPost]
        public void AddNewItem(ItemPrice itemPrice) {
            IItemPriceRepository repository = new ItemPriceRepository();
            repository.AddNewItem(itemPrice.ItemId, itemPrice.Price, itemPrice.Name);
        }
    }
}