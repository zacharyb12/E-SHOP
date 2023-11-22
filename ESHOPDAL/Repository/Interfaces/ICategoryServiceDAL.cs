﻿using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._02.Category;

namespace ESHOPDAL.Repository.Interfaces
{
    public interface ICategoryServiceDAL
    {
        void CreateCategory(CreateCategory category);

        IEnumerable<Category> GetCategories();

        Category GetCategory(Guid id);

        Category GetCategoryByName(string name);

        void UpdateCategory(Category category);
    }
}