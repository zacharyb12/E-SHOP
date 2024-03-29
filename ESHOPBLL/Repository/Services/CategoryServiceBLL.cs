﻿using ESHOPBLL.Repository.Interfaces;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._02.Category;

namespace ESHOPBLL.Repository.Services
{
    public class CategoryServiceBLL : ICategoryServiceBLL
    {

        public ICategoryServiceDAL categoryService;

        public CategoryServiceBLL(ICategoryServiceDAL categoryService)
        {
            this.categoryService = categoryService;
        }

        public void CreateCategory(CreateCategory name)
        {
            categoryService.CreateCategory(name);
        }


        public IEnumerable<Category> GetCategory()
        {
            return categoryService.GetCategories();
        }


        public Category GetCategoryByName(string name)
        {
           return categoryService.GetCategoryByName(name);   
        }


        public Category GetCategoryById(Guid id)
        {
            return categoryService.GetCategoryById(id);
        }


        public void UpdateCategory(Category category, Guid id)
        {
            categoryService.UpdateCategory(category , id);
        }

        public void DeleteCategory(Guid id) 
        {
            categoryService.DeleteCategory(id);
        }

    }
}
