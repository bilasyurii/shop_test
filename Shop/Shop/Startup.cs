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

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ICategoryService, CategoryService>();

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IShopCartItemRepository, ShopCartItemRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IShopCartService, ShopCartService>();

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
