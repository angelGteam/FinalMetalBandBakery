using MetalBandBakery.Core.Domain;
using MetalBandBakery.Core.Services;
using MetalBandBakery.Services;
using System;

namespace MetalBandBakery {
    public class Application {
        private IPriceService _priceService;
        private IStockService _stockService;
        public Application(IStockService stockService, IPriceService priceService) {
            _stockService = stockService;
            _priceService = priceService;
        }

        public void Run() {
            _priceService.SetPrice("M", 10.00M);
            var itemPrice = _priceService.GetPrice("M");
            var order = new Order();
            order.AddItems(UserIsAskedWhatHeWants());
            ShowPurchasingItems(order);
            if(order.CanBePurchase()) {
                var amountPaid = AskUserForMoney();
                CalculateChange(order.AmountToPay, amountPaid);
            }
        }

        private decimal AskUserForMoney() {
            Console.WriteLine("Amount Paid");
            var amountPaid = Console.ReadLine();
            return Convert.ToDecimal(amountPaid);
        }

        private void CalculateChange(decimal amountToPay, decimal amountPaid) {
            if(!ChangeCalculator.CanBeCalculate(amountPaid, amountToPay)) {
                Console.WriteLine($"You need to put more money");
                return;
            }
            var difference = ChangeCalculator.Calculate(amountPaid, amountToPay);
            Console.WriteLine($"your change is: {difference}");
        }
        private void ShowPurchasingItems(Order order) {
            foreach(var orderLine in order.OrderLines) {
                if(!_stockService.CheckStock(orderLine.ItemId)) {
                    Console.WriteLine("Not enough stock " + orderLine.ItemId);
                    return;
                }
                var itemPrice = _priceService.GetPrice(orderLine.ItemId);
                order.SetPrice(orderLine.ItemId, itemPrice);
                _stockService.ReduceStock(orderLine.ItemId);
            }
            Console.WriteLine("Total: " + order.AmountToPay);
        }

        private string[] UserIsAskedWhatHeWants() {
            Console.WriteLine("Items to Purchase?");
            var items = Console.ReadLine().Split(',');
            return items;
        }
    }
}