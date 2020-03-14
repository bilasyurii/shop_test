using Shop.Core.Abstractions;
using Shop.Core.Abstractions.Services;
using Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Services
{
    public class CarService : ICarService
    {
        private IUnitOfWork unitOfWork;

        public CarService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            unitOfWork.Cars.DeleteById(id);

            unitOfWork.SaveChanges();
        }

        public List<Car> GetAll()
        {
            var cars = unitOfWork.Cars.GetAll();

            return cars.ToList();
        }

        public Car GetById(int id)
        {
            Car car = unitOfWork.Cars.GetById(id);

            if (car == null)
                throw new ArgumentException($"Couldn't find a car with id {id}.");

            return car;
        }

        public Car Insert(Car car)
        {
            unitOfWork.Cars.Add(car);

            unitOfWork.SaveChanges();

            return car;
        }

        public Car Update(Car car)
        {
            var existingCar = unitOfWork.Cars.GetById(car.Id);

            if (existingCar == null)
                throw new ArgumentException($"Couldn't find a car with id {car.Id}.");

            existingCar.Name = car.Name;
            existingCar.ShortDescription = car.ShortDescription;
            existingCar.LongDescription = car.LongDescription;
            existingCar.IsFavourite = car.IsFavourite;
            existingCar.IsAvailable = car.IsAvailable;
            existingCar.ImageURL = car.ImageURL;
            existingCar.Price = car.Price;
            existingCar.CategoryId = car.CategoryId;

            unitOfWork.Cars.Update(existingCar);

            unitOfWork.SaveChanges();

            return unitOfWork.Cars.GetById(car.Id);
        }
    }
}
