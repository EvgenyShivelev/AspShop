using Microsoft.EntityFrameworkCore;
using Shop.Web.Data;
using Shop.Web.Interfaces;
using Shop.Web.Model.Aggreagates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    public class OrderRepository : GenericEfRepository<Order>, IOrderRepository
    {
        public OrderRepository(ShopContext dbContext) : base(dbContext)
        {
        }

        public Task<Order> GetByIdWithItemsAsync(int id)
        {
            return _dbContext.Orders
                .Include(o => o.OrderedItems)
                .Include($"{nameof(Order.OrderedItems)}.{nameof(OrderedItem.Item)}")
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
