using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._02.Category;

namespace ESHOPBLL.Repository.Interfaces
{
    public interface ICategoryServiceBLL
    {

        void CreateCategory(CreateCategory name);

        IEnumerable<Category> GetCategory();

        Category GetCategoryByName(string name);

        Category GetCategoryById(Guid id);

        void UpdateCategory(Category category, Guid id);

        void DeleteCategory(Guid id);
    }
}