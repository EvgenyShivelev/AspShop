using Shop.ApplicationCore.Interfaces;
using Shop.Web.Interfaces;
using Shop.Web.Model.Aggreagates;
using Shop.Web.Model.Entities;
using Shop.Web.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IAsyncRepository<Basket> _basketRepository;
        private readonly IAsyncRepository<Goods> _goodsRepository;

        public OrderService(IAsyncRepository<Basket> basketRepository,
            IAsyncRepository<Goods> goodsRepository,
            IAsyncRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
            _basketRepository = basketRepository;
            _goodsRepository = goodsRepository;
        }

        public async Task CreateOrderAsync(int basketId, Address Address)
        {
            var basket = await _basketRepository.GetByIdAsync(basketId);
            var items = new List<OrderedItem>();
            foreach (var item in basket.Items)
            {
                var catalogItem = await _goodsRepository.GetByIdAsync(item.GoodsId);
                var itemOrdered = new PreOrderedItem(catalogItem.Id, catalogItem.Name, catalogItem.PictureUri);
                var orderItem = new OrderedItem(itemOrdered, item.UnitPrice, item.Quantity);
                items.Add(orderItem);
            }
            var order = new Order(basket.PurchaserId, Address, items);

            await _orderRepository.AddAsync(order);
        }
    }
}
