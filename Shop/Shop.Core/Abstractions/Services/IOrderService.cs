using Shop.Core.Entities;

namespace Shop.Core.Abstractions.Services
{
    public interface IOrderService
    {
        void CreateOrder(Order order);
    }
}
