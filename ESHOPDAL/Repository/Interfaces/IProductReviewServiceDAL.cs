using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._04.ProductReview;

namespace ESHOPBLL.Repository.Interfaces
{
    public interface IProductReviewServiceDAL
    {
        void CreateProductReview(ProductReviewDate product);

        ProductReview GetProductReviewById(Guid id);

        IEnumerable<ProductReview> GetProductReviewByRating(int rating);

        IEnumerable<ProductReview> GetProductReviewByUserId(Guid id);

        public IEnumerable<ProductReview> GetProductReviewByProductId(Guid id);

        IEnumerable<ProductReview> GetProductReviews();
    }
}