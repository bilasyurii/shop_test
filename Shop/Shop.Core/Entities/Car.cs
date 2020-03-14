namespace Shop.Core.Entities
{
    public class Car : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string ImageURL { get; set; }

        public ushort Price { get; set; }

        public bool IsFavourite { get; set; }

        public bool Available { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
