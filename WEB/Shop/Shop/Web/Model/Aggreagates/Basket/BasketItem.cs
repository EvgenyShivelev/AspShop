using Shop.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Model.Aggreagates
{
    public class BasketItem: BaseEntity
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int GoodsId { get; set; }
        public int BasketId { get; private set; }

    }
}
