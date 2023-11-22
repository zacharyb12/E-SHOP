using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._04.ProductReview;

namespace ESHOPBLL.Repository.Interfaces
{
    public interface IProductReviewServiceBLL
    {
        void CreateProductReview(CreateProductReview product);

        IEnumerable<ProductReview> GetProductReviewByRating(int rating);

        ProductReview GetProductReviewById(Guid id);

        IEnumerable<ProductReview> GetProductReviewByUserID(Guid id);

        IEnumerable<ProductReview> GetProductReviewByProductId(Guid id);

        IEnumerable<ProductReview> GetProductReviews();
    }
}