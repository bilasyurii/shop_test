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

        private IOrderRepository orders;

        public IOrderRepository Orders =>
            orders ??= new OrderRepository(context);

        private IOrderDetailsRepository orderDetails;

        public IOrderDetailsRepository OrderDetails =>
            orderDetails ??= new OrderDetailsRepository(context);

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
