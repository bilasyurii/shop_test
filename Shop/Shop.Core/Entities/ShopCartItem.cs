using System;

namespace Shop.Core.Entities
{
    public class ShopCartItem : IEntity<int>
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public Guid ShopCartId { get; set; }
    }
}
