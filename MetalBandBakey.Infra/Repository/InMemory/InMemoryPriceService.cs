using MetalBandBakery.Core.Services;
using System.Collections.Generic;

namespace MetalBandBakey.Infra.Repository
{
	public class InMemoryPriceService : IPriceService
	{
		private static Dictionary<string, decimal> _prices;

		public InMemoryPriceService()
		{
			_prices = new Dictionary<string, decimal>() { { "B", 0.65m }, { "M", 1.00m }, { "C", 1.35m }, { "W", 1.50m } };
		}

        public IEnumerable<ItemPrice> GetAllItemPrices() {
            throw new System.NotImplementedException();
        }

        public decimal GetPrice(string itemId)
		{
			if (!Exists(itemId))
				return 0m;
			return _prices[itemId];
		}

        public void SetPrice(string itemId, decimal quantity) {
            throw new System.NotImplementedException();
        }

        private bool Exists(string itemId)
		{
			return _prices.ContainsKey(itemId);
		}
	}
}