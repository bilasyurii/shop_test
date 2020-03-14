using Shop.Core.Abstractions;
using Shop.Core.Abstractions.Repositories;
using Shop.DAL.Repositories;

namespace Shop.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ShopContext context;

        public UnitOfWork(ShopContext context)
        {
            this.context = context;
        }

        private ICarRepository cars;

        public ICarRepository Cars =>
            cars ??= new CarRepository(context);

        private ICategoryRepository categories;

        public ICategoryRepository Categories =>
            categories ??= new CategoryRepository(context);

        private IShopCartItemRepository shopCartItems;

        public IShopCartItemRepository ShopCartItems =>
            shopCartItems ??= new ShopCartItemRepository(context);

        public void Dispose()
        {
            if (context != null)
                context.Dispose();
            context = null;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
