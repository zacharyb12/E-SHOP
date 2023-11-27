using ESHOPBLL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._03.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESHOPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceBLL productService;

        public ProductController(IProductServiceBLL productService)
        {
            this.productService = productService;
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProduct product)
        {
            if (product == null) 
            {
                return BadRequest();
            }
            productService.CreateProduct(product);

            return Ok(product);
        }

        [HttpGet]
        public IEnumerable<ESHOPDomainModels.Models._03.Product.Product> GetProducts() 
        {
            return productService.GetProducts();
        }

        [HttpGet("id")]
        public Product GetProductById(Guid id) 
        {
           return productService.GetProductById(id);
        }

        [HttpGet("name")]
        public Product GetProductByName(string name)
        {
            return productService.GetProductByName(name);
        }

        [HttpGet("CategoryName")]
        public IEnumerable<Product> GetProductsByCategoryName(string name)
        {
            return productService.GetProductsByCategoryName(name);
        }

        [HttpPost("info")]
        public IActionResult UpdateProductInfo(UpdateProduct product, string info , Guid id)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest();
            }

            productService.UpdateProductInfo(product, info, id);
            return Ok(product);
        }

        [HttpPut("id")]
        public IActionResult UpdateProduct(UpdateProduct product,  Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            productService.UpdateProduct(product, id);
            return Ok(product);
        }

    }
}
