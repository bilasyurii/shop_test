using Shop.Core.Abstractions.Repositories;
using Shop.Core.Entities;

namespace Shop.DAL.Repositories
{
    public class ShopCartItemRepository : BaseRepository<ShopCartItem, int>, IShopCartItemRepository
    {
        public ShopCartItemRepository(ShopContext context) : base(context) { }
    }
}
