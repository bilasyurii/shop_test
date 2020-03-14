using Microsoft.AspNetCore.Mvc;
using Shop.Core.Abstractions.Services;
using Shop.ViewModels;

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

        public IActionResult Index()
        {
            ViewBag.Title = "Cars";

            var carViewModel = new CarViewModel()
            {
                Cars = carService.GetAll(),
                CurrentCategory = "Cars"
            };

            return View(carViewModel);
        }
    }
}
