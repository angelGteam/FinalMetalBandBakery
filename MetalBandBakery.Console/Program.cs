using MetalBandBakery.Core.Services;
using MetalBandBakey.Infra.Repository;

namespace MetalBandBakery {
    internal class Program {
        private static IStockService _wcfStockService = new SoapStockService();
        private static IPriceService _rfPriceService = new RestfullPriceService();
        private static IStockService _stockService = new InMemoryStockService();
        private static IPriceService _priceService = new InMemoryPriceService();

        private static void Main(string[] args) {
            var application = new Application(_wcfStockService, _rfPriceService);
            application.Run();
        }
    }
}