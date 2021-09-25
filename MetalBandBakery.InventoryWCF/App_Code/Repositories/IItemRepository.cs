namespace MetalBandBakery.InventoryWCF.Repositories
{
	public interface IInventoryRepository
	{
		Item GetItem(string itemId);

		bool Save(Item item);
	}
}