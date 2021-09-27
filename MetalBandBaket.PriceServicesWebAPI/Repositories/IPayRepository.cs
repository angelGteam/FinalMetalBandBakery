using BakeryLibraries;
using System.Collections.Generic;

namespace MetalBandBakery.PriceServicesWebAPI.Repositories {
    public interface IPayRepository {
        void Pay(ItemPay itemPay);
        string ReadRepositoryOfItems();
    }
}