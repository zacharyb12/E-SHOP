using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._02.Category;

namespace ESHOPBLL.Repository.Interfaces
{
    public interface ICategoryServiceBLL
    {
        void CreateCategory(CreateCategory name);

        IEnumerable<Category> GetCategory();

        Category GetCategoryByName(string name);

        void UpdateCategory(Category category);
    }
}