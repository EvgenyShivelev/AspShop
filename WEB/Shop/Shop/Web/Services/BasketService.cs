using Shop.ApplicationCore.Interfaces;
using Shop.Web.Interfaces;
using Shop.Web.Model.Aggreagates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Services
{
    public class BasketService : IBasketService
    {
        private readonly IAsyncRepository<Basket> _basketRepository;
        private readonly IAppLogger<BasketService> _logger;

        public BasketService(IAsyncRepository<Basket> basketRepository, IAppLogger<BasketService> logger)
        {
            _basketRepository = basketRepository;
            _logger = logger;
        }

        public async Task AddItemToBasket(int basketId, int goodsId, decimal price, int quantity = 1)
        {
            var basket = await _basketRepository.GetByIdAsync(basketId);

            basket.AddItem(goodsId, price, quantity);

            await _basketRepository.UpdateAsync(basket);
        }

        public async Task DeleteBasketAsync(int basketId)
        {
            var basket = await _basketRepository.GetByIdAsync(basketId);
            await _basketRepository.DeleteAsync(basket);
        }

        public async Task<int> GetBasketItemCountAsync(string userName)
        {
            var _basket = (await _basketRepository.GetByIdAsync( t => t.PurchaserId == userName));
            if (_basket == null)
            {
                _logger.LogInformation($"LOG: Корзина пользователя {userName} - пуста");
                return 0;
            }
            int _count = _basket.Items.Sum(i => i.Quantity);
            _logger.LogInformation($"LOG: Корзина пользователя {userName} имеет {_count} товаров.");
            return _count;
        }

        public async Task SetQuantities(int basketId, Dictionary<string, int> quantities)
        {
            var _basket = await _basketRepository.GetByIdAsync(basketId);

            foreach (var item in _basket.Items)
            {
                if (quantities.TryGetValue(item.Id.ToString(), out var quantity))
                {
                    if (_logger != null) _logger.LogInformation($"LOG: Обновления для предмета с ID:{item.Id} изменения: {item.Quantity} -> {quantity}.");
                    item.Quantity = quantity;
                }
            }

            _basket.RemoveEmptyItems();
            await _basketRepository.UpdateAsync(_basket);
        }
    }
}
