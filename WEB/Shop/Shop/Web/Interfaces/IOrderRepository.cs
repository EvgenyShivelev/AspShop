using Shop.ApplicationCore.Interfaces;
using Shop.Web.Model.Aggreagates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Interfaces
{
    public interface IOrderRepository: IAsyncRepository<Order>
    {
        Task<Order> GetByIdWithItemsAsync(int id);
    }
} 
