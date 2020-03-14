using Shop.Core.Abstractions.Repositories;
using Shop.Core.Entities;

namespace Shop.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private ShopContext context;

        public OrderRepository(ShopContext context)
        {
            this.context = context;
        }

        public void Add(Order order)
        {
            context.Orders.Add(order);
        }
    }
}
