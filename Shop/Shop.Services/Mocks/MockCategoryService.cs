using Shop.Core.Abstractions.Services;
using Shop.Core.Entities;
using System.Collections.Generic;

namespace Shop.Services.Mocks
{
    public class MockCategoryService : ICategoryService
    {
        public void Delete(int id) { }

        public List<Category> GetAll()
        {
            return new List<Category> {
                new Category() { Name = "Electrocars", Description = "Elon Musk rules!" },
                new Category() { Name = "Classic cars", Description = "In-engine burning cars" }
            };
        }

        public Category GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Category Insert(Category category)
        {
            throw new System.NotImplementedException();
        }

        public Category Update(Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}
