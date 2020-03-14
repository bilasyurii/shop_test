using Shop.Core.Abstractions;
using Shop.Core.Abstractions.Services;
using Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Services
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            unitOfWork.Categories.DeleteById(id);

            unitOfWork.SaveChanges();
        }

        public List<Category> GetAll()
        {
            var categories = unitOfWork.Categories.GetAll();

            return categories.ToList();
        }

        public Category GetById(int id)
        {
            Category category = unitOfWork.Categories.GetById(id);

            if (category == null)
                throw new ArgumentException($"Couldn't find a category with id {id}.");

            return category;
        }

        public Category Insert(Category category)
        {
            unitOfWork.Categories.Add(category);

            unitOfWork.SaveChanges();

            return category;
        }

        public Category Update(Category category)
        {
            var existingCategory = unitOfWork.Categories.GetById(category.Id);

            if (existingCategory == null)
                throw new ArgumentException($"Couldn't find a category with id {category.Id}.");

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;

            unitOfWork.Categories.Update(existingCategory);

            unitOfWork.SaveChanges();

            return unitOfWork.Categories.GetById(category.Id);
        }
    }
}
