using Shop.ApplicationCore.Entities;
using Shop.Web.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Model.Aggreagates
{
    public class Order: BaseEntity
    {
        private Order()
        {

        }
        
        public Order(string purchaserId, Address address, List<OrderedItem> items)
        {
            PurchaserId = purchaserId;
            Address = address;
            _orderedItems = items;
        }
        public string PurchaserId { get; private set; }

        public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.Now;
        public Address Address { get; private set; }

        private readonly List<OrderedItem> _orderedItems = new List<OrderedItem>();

        public IReadOnlyCollection<OrderedItem> OrderedItems => _orderedItems.AsReadOnly();

        public decimal CheckoutTotalsum()
        {
            var _total = 0m;
            foreach (var item in _orderedItems)
            {
                _total += item.UnitPrice * item.Units;
            }
            return _total;
        }
    }
}
