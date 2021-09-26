using System.Collections.Generic;
using System.Linq;

namespace MetalBandBakery.Core.Domain {
    public class Order {
        private List<OrderLine> _listOfItems;

        public Order() {
            _listOfItems = new List<OrderLine>();
        }

        public decimal AmountToPay { get { return _listOfItems.Sum(t => t.TotalPrice); } }

        public IEnumerable<OrderLine> OrderLines { get { return _listOfItems; } }

        public void AddItems(OrderLine order) {
            _listOfItems.Add(order);
        }

        public bool CanBePurchase() {
            return AmountToPay > 0;
        }

        public void SetPrice(string itemId, decimal itemPrice) {
            var item = _listOfItems.FirstOrDefault(li => li.ItemId == itemId);
            item.BasePrice = itemPrice;
        }
    }
}