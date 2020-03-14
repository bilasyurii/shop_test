using Microsoft.AspNetCore.Mvc;
using Shop.Core.Abstractions.Services;
using Shop.Core.Entities;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService orderService;
        private IShopCartService shopCartService;
        private ShopCart shopCart;

        public OrderController(IOrderService orderService, IShopCartService shopCartService, 
                               ShopCart shopCart)
        {
            this.orderService = orderService;
            this.shopCartService = shopCartService;
            this.shopCart = shopCart;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Order order)
        {
            shopCart.Items = shopCartService.GetCartItems();

            if (shopCart.Items.Count == 0)
            {
                ModelState.AddModelError("", "You must have items in the cart.");
            }

            if (ModelState.IsValid)
            {
                orderService.CreateOrder(order);

                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Order has been processed correctly.";

            return View();
        }
    }
}