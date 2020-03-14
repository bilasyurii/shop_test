using Microsoft.EntityFrameworkCore;
using Shop.Core.Abstractions;
using Shop.Core.Abstractions.Services;
using Shop.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Services
{
    public class ShopCartService : IShopCartService
    {
        private IUnitOfWork unitOfWork;
        private ShopCart shopCart;

        public ShopCartService(IUnitOfWork unitOfWork, ShopCart shopCart)
        {
            this.unitOfWork = unitOfWork;
            this.shopCart = shopCart;
        }

        public void AddToCart(Car car)
        {
            unitOfWork.ShopCartItems.Add(new ShopCartItem()
            {
                ShopCartId = shopCart.Id,
                Car = car
            });

            unitOfWork.SaveChanges();
        }

        public List<ShopCartItem> GetCartItems()
        {
            return unitOfWork.ShopCartItems
                             .Find(item => item.ShopCartId == shopCart.Id)
                             .Include(item => item.Car).ToList();
        }
    }
}
