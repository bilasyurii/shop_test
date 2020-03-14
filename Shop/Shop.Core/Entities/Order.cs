using System;
using System.Collections.Generic;

namespace Shop.Core.Entities
{
    public class Order : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime OrderTime { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }
    }
}
