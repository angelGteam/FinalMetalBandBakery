using System.Collections.Generic;
namespace MetalBandBakery.Core.Services {
    public interface IPayService {
        void Pay(double quantity, string payer, string receiver);
        string ReadRepositoryOfItems();
    }
}