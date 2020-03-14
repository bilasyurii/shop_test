using Shop.Core.Entities;
using System.Collections.Generic;

namespace Shop.Core.Abstractions.Services
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int id);
        Car Insert(Car car);
        Car Update(Car car);
        void Delete (int id);
    }
}
