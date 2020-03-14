using Microsoft.AspNetCore.Mvc;
using Shop.Core.Abstractions.Repositories;
using Shop.Core.Entities;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository orderRepository;
        private ShopCart shopCart;

        public OrderController(IOrderRepository orderRepository, ShopCart shopCart)
        {
            this.orderRepository = orderRepository;
            this.shopCart = shopCart;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}