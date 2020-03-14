using Shop.Core.Abstractions;
using Shop.Core.Abstractions.Services;
using Shop.Core.Entities;
using System;

namespace Shop.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork unitOfWork;

        private ShopCart shopCart;

        public OrderService(IUnitOfWork unitOfWork, ShopCart shopCart)
        {
            this.unitOfWork = unitOfWork;
            this.shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;

            unitOfWork.Orders.Add(order);

            var items = shopCart.Items;

            foreach (var item in items)
            {
                var orderDetails = new OrderDetails()
                {
                    CarId = item.CarId,
                    OrderId = order.Id,
                    Price = item.Car.Price
                };

                unitOfWork.OrderDetails.Add(orderDetails);
            }

            unitOfWork.SaveChanges();
        }
    }
}
