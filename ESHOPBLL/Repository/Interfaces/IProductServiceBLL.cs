using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._03.Product;

namespace ESHOPBLL.Repository.Interfaces
{
    public interface IProductServiceBLL
    {
        void CreateProduct(CreateProduct product);

        Product GetProductById(Guid id);

        Product GetProductByName(string name);

        IEnumerable<Product> GetProductsByCategoryName(string name);

        IEnumerable<Product> GetProducts();

        void UpdateProductInfo(UpdateProduct product, string info, Guid id);
    }
}