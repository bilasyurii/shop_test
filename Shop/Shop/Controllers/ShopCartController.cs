using Microsoft.AspNetCore.Mvc;
using Shop.Core.Abstractions.Repositories;
using Shop.Core.Abstractions.Services;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly ICarRepository carRepository;

        private readonly IShopCartService shopCartService;

        public ShopCartController(ICarRepository carRepository, IShopCartService shopCartService)
        {
            this.carRepository = carRepository;
            this.shopCartService = shopCartService;
        }

        public ActionResult Index()
        {
            var items = shopCartService.GetCartItems();

            var shopCartViewModel = new ShopCartViewModel() { ShopCartItems = items };

            return View(shopCartViewModel);
        }

        public RedirectToActionResult Add(int id)
        {
            var item = carRepository.GetById(id);

            if (item != null)
            {
                shopCartService.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
