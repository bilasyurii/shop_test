using Shop.Core.Abstractions.Repositories;
using System;

namespace Shop.Core.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        ICarRepository Cars { get; }

        ICategoryRepository Categories { get; }

        IShopCartItemRepository ShopCartItems { get; }

        void SaveChanges();
    }
}
