namespace Shop.Core.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
