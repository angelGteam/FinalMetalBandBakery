using MetalBandBakery.PriceServicesWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace MetalBandBaket.PriceServicesWebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PricesController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<PricesController> _logger;

		public PricesController(ILogger<PricesController> logger)
		{
			_logger = logger;
		}
		[Route("GetAll")]
		[HttpGet]
		public IEnumerable<ItemData> GetAllItems()
		{
			IItemPriceRepository repository = new ItemPriceRepository();
			var p = repository.GetAllItems();
			return p;
		}
		[Route("GetOne/itemId/{itemId}")] 
		[HttpGet]
		public ItemData GetOneItem(string itemId)
		{
			IItemPriceRepository repository = new ItemPriceRepository();
			var itemPrice = repository.GetOneItem(itemId);
			return itemPrice;
		}
		[Route("SetPrice")]
		[HttpPost]
		public void ChangePrice(ItemData itemPrice) {
			IItemPriceRepository repository = new ItemPriceRepository();
			repository.SetPrice(itemPrice.ItemId, itemPrice.Price);
		}
		[Route("AddNewItem")]
		[HttpPost]
		public void AddNewItem(ItemData itemPrice) {
			IItemPriceRepository repository = new ItemPriceRepository();
			repository.AddNewItem(itemPrice.ItemId, itemPrice.Price, itemPrice.Name);
		}
	}
}