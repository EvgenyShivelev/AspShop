using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Interfaces
{
    interface IBasketService
    {
        Task<int> GetBasketItemCountAsync(string userName);
        Task AddItemToBasket(int basketId, int goodsId, decimal price, int quantity = 1);
        Task SetQuantities(int basketId, Dictionary<string, int> quantities);
        Task DeleteBasketAsync(int basketId);
    }
}
