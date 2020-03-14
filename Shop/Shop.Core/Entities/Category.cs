using System.Collections.Generic;

namespace Shop.Core.Entities
{
    public class Category : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Car> Cars { get; set; }
    }
}
