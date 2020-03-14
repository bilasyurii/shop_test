using Shop.Core.Abstractions;
using Shop.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Shop.DAL
{
    public class Seeder
    {
        private static Dictionary<string, Category> categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(categories == null)
                {
                    categories = new Dictionary<string, Category>();

                    categories.Add("Electrocars", new Category()
                    {
                        Name = "Electrocars",
                        Description = "Elon Musk rules!"
                    });

                    categories.Add("Classic cars", new Category()
                    {
                        Name = "Classic cars",
                        Description = "In-engine burning cars"
                    });
                }

                return categories;
            }
        }

        public static void Seed(IUnitOfWork unitOfWork)
        {
            SeedCategories(unitOfWork);
        }

        private static void SeedCategories(IUnitOfWork unitOfWork)
        {
            if (!unitOfWork.Categories.GetAll().Any())
            {
                unitOfWork.Categories.AddMany(Categories.Select(cat => cat.Value));
            }

            if (!unitOfWork.Cars.GetAll().Any())
            {
                unitOfWork.Cars.AddMany(new List<Car>
                {
                    new Car()
                    {
                        Name = "Tesla",
                        ImageURL = "/img/tesla.jpg",
                        Price = 45000,
                        ShortDescription = "Nice",
                        LongDescription = "Very nice",
                        IsFavourite = true,
                        IsAvailable = true,
                        Category = Categories["Electrocars"]
                    },
                    new Car()
                    {
                        Name = "Mercedes",
                        ImageURL = "/img/mercedes.jpg",
                        Price = 40000,
                        ShortDescription = "Comfortable",
                        LongDescription = "Comfortable for city",
                        IsFavourite = false,
                        IsAvailable = false,
                        Category = Categories["Classic cars"]
                    },
                    new Car()
                    {
                        Name = "BMW",
                        ImageURL = "/img/bmw.jpg",
                        Price = 65000,
                        ShortDescription = "Cool",
                        LongDescription = "Comfortable for city",
                        IsFavourite = true,
                        IsAvailable = true,
                        Category = Categories["Classic cars"]
                    }
                });
            }

            unitOfWork.SaveChanges();
        }
    }
}
