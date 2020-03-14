using Shop.Core.Abstractions.Repositories;
using Shop.Core.Entities;

namespace Shop.DAL.Repositories
{
    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(ShopContext context) : base(context) { }
    }
}
