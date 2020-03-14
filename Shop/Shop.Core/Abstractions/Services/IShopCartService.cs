using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Shop.Core.Entities;

namespace Shop.Core.Abstractions.Services
{
    public interface IShopCartService
    {
        void AddToCart(Car car);

        List<ShopCartItem> GetCartItems();

        public static ShopCart GetCart(IServiceProvider services)
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

            return new ShopCart() { Id = shopCartId };
        }
    }
}
