using Shop.Core.Entities;
using System.Collections.Generic;

namespace Shop.Core.Abstractions.Services
{
    public interface ICarService
    {
        List<Car> GetAll();

        List<Car> GetFavourite();

        Car GetById(int id);

        List<Car> GetByCategory(string category);

        Car Insert(Car car);

        Car Update(Car car);

        void Delete (int id);
    }
}
