using System;
using System.Collections.Generic;

namespace Shop.Core.Entities
{
    public class ShopCart : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public List<ShopCartItem> Items { get; set; }
    }
}
