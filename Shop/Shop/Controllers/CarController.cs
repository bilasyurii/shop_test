using Microsoft.AspNetCore.Mvc;
using Shop.Core.Abstractions.Services;
using Shop.Core.Entities;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService carService;
        private readonly ICategoryService categoryService;

        public CarController(ICarService carService, ICategoryService categoryService)
        {
            this.carService = carService;
            this.categoryService = categoryService;
        }

        [Route("Car")]
        [Route("Car/{category}")]
        public IActionResult Index(string category)
        {
            IEnumerable<Car> cars = null;
            string currentCategory = "";

            if (string.IsNullOrEmpty(category))
            {
                cars = carService.GetAll().OrderBy(car => car.Id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = carService.GetByCategory("Electrocars")
                                     .OrderBy(car => car.Id);
                    currentCategory = "Electrocars";
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = carService.GetByCategory("Classic cars")
                                     .OrderBy(car => car.Id);
                    currentCategory = "Classic cars";
                }
            }

            var carViewModel = new CarViewModel()
            {
                Cars = cars.ToList(),
                CurrentCategory = currentCategory
            };

            ViewBag.Title = "Cars";

            return View(carViewModel);
        }
    }
}
