using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities;

namespace Shop.DAL
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ShopCartItem> ShopCartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
