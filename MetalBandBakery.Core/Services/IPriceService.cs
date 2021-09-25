namespace MetalBandBakery.Core.Services
{
	public interface IPriceService
	{
		decimal GetPrice(string itemId);
		void SetPrice(string itemId, decimal quantity);
	}
}