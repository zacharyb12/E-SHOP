using ESHOPBLL.Repository.Interfaces;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._03.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPBLL.Repository.Services
{
    public class ProductServiceBLL : IProductServiceBLL
    {
        private IProductServiceDAL productService;

        public ProductServiceBLL(IProductServiceDAL productService)
        {
            this.productService = productService;
        }

        public void CreateProduct(CreateProduct product)
        {
            productService.CreateProduct(product);
        }

        public IEnumerable<ESHOPDomainModels.Models._03.Product.Product> GetProducts()
        {
            return productService.GetProducts();
        }

        public Product GetProductById(Guid id)
        {
            return productService.GetById(id);
        }

        public Product GetProductByName(string name)
        {
            return productService.GetByName(name);
        }

        public void UpdateProductInfo(UpdateProduct product, string info, Guid id)
        {
            switch (info)
            {
                case "Name":
                    info = "Name";
                    break;
                case "Price":
                    info = "Price";
                    break;
                case "ImagePath":
                    info = "ImagePath";
                    break;
                case "Description":
                    info = "Description";
                    break;
                case "StockQuantity":
                    info = "StockQuantity";
                    break;
                case "Rating":
                    info = "Rating";
                    break;

                default:
                    throw new ArgumentException("Nom de colonne non valide.", nameof(info));
            }
                    productService.UpdateProductInfo(product, info, id);
        }

    }
}
