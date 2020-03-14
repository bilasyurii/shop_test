using Shop.Core.Abstractions.Repositories;
using Shop.Core.Entities;

namespace Shop.DAL.Repositories
{
    public class OrderDetailsRepository : BaseRepository<OrderDetails, int>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(ShopContext context) : base(context) { }
    }
}
