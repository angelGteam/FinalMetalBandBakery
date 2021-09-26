using System.Collections.Generic;

namespace MetalBandBakery.InventoryWCF.Repositories {
    public interface IInventoryRepository {
        ItemStock GetItem(string itemId);
        void SaveChanges();
        List<ItemStock> CheckCompleteStock();
    }
}