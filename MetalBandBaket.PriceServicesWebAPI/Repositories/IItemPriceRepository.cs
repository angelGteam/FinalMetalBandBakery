using System.Collections.Generic;

namespace MetalBandBakery.PriceServicesWebAPI.Repositories
{
	public interface IItemPriceRepository
	{
		ItemPrice GetOneItem(string itemId);
		IEnumerable<ItemPrice> GetAllItems();
        void SetPrice(string itemId, decimal price);
        void AddNewItem(string itemId, decimal price, string name);
    }
}