using Microsoft.AspNetCore.Mvc;
using Shop.Core.Abstractions.Services;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private ICarService carService;

        public HomeController(ICarService carService)
        {
            this.carService = carService;
        }

        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                FavouriteCars = carService.GetFavourite()
            };

            return View(homeViewModel);
        }
    }
}
