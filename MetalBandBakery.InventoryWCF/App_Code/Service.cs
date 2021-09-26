using MetalBandBakery.InventoryWCF.Repositories;
using System.Collections.Generic;

public class Service : IService {
    public List<ItemStock> CheckCompleteStock() {
        IInventoryRepository inventoryRepository = new InventoryRepository();
        return inventoryRepository.CheckCompleteStock();
    }

    public int CheckStock(string itemId) {
        IInventoryRepository inventoryRepository = new InventoryRepository();
        var item = inventoryRepository.GetItem(itemId);
        if(item == null)
            return 0;
        inventoryRepository.SaveChanges();
        return item.Quantity;
    }
    public void IncreaseStock(string itemId, int quantity) {
        IInventoryRepository inventoryRepository = new InventoryRepository();
        var item = inventoryRepository.GetItem(itemId);
        item.Quantity += quantity;
        inventoryRepository.SaveChanges();
    }

    public bool ReduceStock(string itemId, int quantity) {
        IInventoryRepository inventoryRepository = new InventoryRepository();
        var item = inventoryRepository.GetItem(itemId);
        if(item == null)
            return false;
        if(item.Quantity <= 0)
            return false;
        item.Quantity -= quantity;
        inventoryRepository.SaveChanges();
        return true;
    }
}