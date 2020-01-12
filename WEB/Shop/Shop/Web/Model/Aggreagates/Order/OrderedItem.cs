using Shop.ApplicationCore.Entities;
using Shop.Web.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Model.Aggreagates
{
    public class OrderedItem: BaseEntity 
    {
        public PreOrderedItem Item { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Units { get; private set; }

        private OrderedItem()
        {
        }

        public OrderedItem(PreOrderedItem item, decimal unitPrice, int units)
        {
            Item = item;
            UnitPrice = unitPrice;
            Units = units;
        }
    }
}
