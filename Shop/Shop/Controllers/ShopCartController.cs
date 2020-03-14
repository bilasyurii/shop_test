using Microsoft.AspNetCore.Mvc;
using Shop.Core.Abstractions.Repositories;
using Shop.Core.Entities;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly ICarRepository carRepository;

        private readonly ShopCart shopCart;

        public ShopCartController(ICarRepository carRepository, ShopCart shopCart)
        {
            this.carRepository = carRepository;
            this.shopCart = shopCart;
        }

        public ActionResult Index()
        {
            var items = shopCart.GetItems();
            shopCart.Items = items;

            var shopCartViewModel = new ShopCartViewModel() { ShopCart = shopCart };

            return View(shopCartViewModel);
        }

        public RedirectToActionResult Add(int id)
        {
            var item = carRepository.GetById(id);

            if (item != null)
            {
                shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
