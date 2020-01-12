using Shop.Web.Model.ValueObjects;
using System.Threading.Tasks;

namespace Shop.Web.Interfaces
{
    interface IOrderService
    {
        Task CreateOrderAsync(int basketId, Address address);
    }
}
