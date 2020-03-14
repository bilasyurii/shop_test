using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Shop.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Core.Entities
{
    public class ShopCart : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public List<ShopCartItem> Items { get; set; }

        private IUnitOfWork unitOfWork;

        public ShopCart() { }

        public ShopCart(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public static ShopCart GetCart(IServiceProvider services, IUnitOfWork unitOfWork)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()
                                       ?.HttpContext.Session;

            string storedId = session.GetString("CartId");

            Guid shopCartId;

            if (storedId == null)
                shopCartId = Guid.NewGuid();
            else
                shopCartId = Guid.Parse(storedId);

            session.SetString("CartId", shopCartId.ToString());

            return new ShopCart(unitOfWork) { Id = shopCartId };
        }

        public void AddToCart(Car car)
        {
            unitOfWork.ShopCartItems.Add(new ShopCartItem()
            {
                ShopCartId = Id,
                Car = car
            });

            unitOfWork.SaveChanges();
        }

        public List<ShopCartItem> GetItems()
        {
            return unitOfWork.ShopCartItems.Find(item => item.ShopCartId == Id).ToList();
        }
    }
}
