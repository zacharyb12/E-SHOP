using ESHOPBLL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._04.ProductReview;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESHOPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductReviewController : ControllerBase
    {
        private IProductReviewServiceBLL productReviewService;

        public ProductReviewController(IProductReviewServiceBLL productReviewService)
        {
            this.productReviewService = productReviewService;
        }

        [HttpPost]
        public void CreateProductReview(CreateProductReview productReview)
        {
            productReviewService.CreateProductReview(productReview);
        }

        [HttpGet]
        public IEnumerable<ProductReview> GetProductsReview() 
        {
            return productReviewService.GetProductReviews();
        }

        [HttpGet("idProdRev")]
        public ProductReview GetProductReviewById(Guid id) 
        {
            return productReviewService.GetProductReviewById(id);
        }

        [HttpGet("idUser")]
        public IEnumerable<ProductReview> GetProductReviewByUserId(Guid id)
        {
            return productReviewService.GetProductReviewByUserID(id);
        }

        [HttpGet("rating")]
        public IEnumerable<ProductReview> GetProductReviewByRating(int rating)
        {
            return productReviewService.GetProductReviewByRating(rating);
        }
    }
}
