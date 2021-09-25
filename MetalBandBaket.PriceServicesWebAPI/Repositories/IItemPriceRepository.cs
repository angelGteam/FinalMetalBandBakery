using System.Collections.Generic;

namespace MetalBandBakery.PriceServicesWebAPI.Repositories
{
	public interface IItemPriceRepository
	{
		ItemData GetOneItem(string itemId);
		IEnumerable<ItemData> GetAllItems();
        void SetPrice(string itemId, decimal price);
        void AddNewItem(string itemId, decimal price, string name);
    }
}