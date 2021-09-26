using System.Collections.Generic;
namespace MetalBandBakery.Core.Services {
    public interface IPriceService {
        decimal GetPrice(string itemId);
        void SetPrice(string itemId, decimal quantity);
        IEnumerable<ItemPrice> GetAllItemPrices();

    }
}