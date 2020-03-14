using Shop.Core.Entities;

namespace Shop.Core.Abstractions.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
    }
}
