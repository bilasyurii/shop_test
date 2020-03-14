using Shop.Core.Abstractions.Services;
using Shop.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Services.Mocks
{
    public class MockCarService : ICarService
    {
        private readonly ICategoryService categoryService = new MockCategoryService();

        public void Delete(int id) {}

        public List<Car> GetAll()
        {
            return new List<Car> {
                new Car()
                {
                    Name = "Tesla",
                    ImageURL = "/img/tesla.jpg",
                    Price = 45000,
                    ShortDescription = "Nice",
                    LongDescription = "Very nice",
                    IsFavourite = true,
                    Available = true,
                    Category = categoryService.GetAll().First()
                },
                new Car()
                {
                    Name = "Mercedes",
                    ImageURL = "/img/mercedes.jpg",
                    Price = 40000,
                    ShortDescription = "Comfortable",
                    LongDescription = "Comfortable for city",
                    IsFavourite = false,
                    Available = false,
                    Category = categoryService.GetAll().Last()
                },
                new Car()
                {
                    Name = "BMW",
                    ImageURL = "/img/bmw.jpg",
                    Price = 65000,
                    ShortDescription = "Cool",
                    LongDescription = "Comfortable for city",
                    IsFavourite = true,
                    Available = true,
                    Category = categoryService.GetAll().Last()
                }
            };
        }

        public Car GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Car Insert(Car car)
        {
            throw new System.NotImplementedException();
        }

        public Car Update(Car car)
        {
            throw new System.NotImplementedException();
        }
    }
}
