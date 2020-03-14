using Shop.Core.Entities;
using System.Collections.Generic;

namespace Shop.Core.Abstractions.Services
{
    public interface ICategoryService
    {
        List<Category> GetAll();

        Category GetById(int id);

        Category Insert(Category category);

        Category Update(Category category);

        void Delete(int id);
    }
}
