using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._03.Product;

namespace ESHOPDAL.Repository.Interfaces
{
    public interface IProductServiceDAL
    {

        void CreateProduct(CreateProduct product);

        Product GetById(Guid id);

        Product GetByName(string name);

        IEnumerable<Product> GetProductsByCategory(Guid name);

        IEnumerable<Product> GetProducts();

        void UpdateProductInfo(UpdateProduct product, string info, Guid id);

        void UpdateProduct(UpdateProduct product, Guid id);

    }
}