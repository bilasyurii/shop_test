using Microsoft.AspNetCore.Mvc;
using Shop.Core.Abstractions.Services;
using Shop.Core.Entities;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {
        private ICarService carService;

        private IShopCartService shopCartService;

        private ShopCart shopCart;

        public ShopCartController(ICarService carService, IShopCartService shopCartService,
                                  ShopCart shopCart)
        {
            this.carService = carService;
            this.shopCartService = shopCartService;
            this.shopCart = shopCart;
        }

        public ActionResult Index()
        {
            shopCart.Items = shopCartService.GetCartItems();

            var shopCartViewModel = new ShopCartViewModel() { ShopCartItems = shopCart.Items };

            return View(shopCartViewModel);
        }

        public RedirectToActionResult Add(int id)
        {
            var item = carService.GetById(id);

            if (item != null)
            {
                shopCartService.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
