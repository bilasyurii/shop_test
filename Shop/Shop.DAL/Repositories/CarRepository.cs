using Shop.Core.Abstractions.Repositories;
using Shop.Core.Entities;

namespace Shop.DAL.Repositories
{
    public class CarRepository : BaseRepository<Car, int>, ICarRepository
    {
        public CarRepository(ShopContext context) : base(context) { }
    }
}
