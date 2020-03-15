using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Core.Abstractions.Services;
using Shop.DAL;
using Microsoft.EntityFrameworkCore;
using Shop.Core.Abstractions.Repositories;
using Shop.DAL.Repositories;
using Shop.Core.Abstractions;
using Shop.Services;
using Microsoft.AspNetCore.Http;
using Shop.Core.Entities;

namespace Shop
{
    public class Startup
    {
        private IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ShopContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IShopCartItemRepository, ShopCartItemRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IShopCartService, ShopCartService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => IShopCartService.GetCart(sp));

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
                              IUnitOfWork unitOfWork)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", 
                                template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(name: "categoryFilter",
                                template: "Car/{action}/{category?}", 
                                defaults: new { Controller = "Car", action = "Index" });
            });

            Seeder.Seed(unitOfWork);
        }
    }
}
