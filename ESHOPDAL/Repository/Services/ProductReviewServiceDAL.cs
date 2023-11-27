using Dapper;
using ESHOPBLL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._04.ProductReview;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPBLL.Repository.Services
{
    public class ProductReviewServiceDAL : IProductReviewServiceDAL
    {
        private SqlConnection connection;

        public ProductReviewServiceDAL(SqlConnection connection)
        {
            this.connection = connection;
        }

        // create product review - user
        public void CreateProductReview(ProductReview product)
        {
            string sql = " INSERT INTO ProductReview (ProductId , UserId , Rating , ReviewText , ReviewDate ) VALUES ( @ProductId , @UserId , @Rating , @ReviewText , @ReviewDate)";

            product.ReviewDate = DateTime.Today;

            var parameters = new DynamicParameters();
            parameters.Add("ProductId", product.ProductId);
            parameters.Add("UserId", product.UserId);
            parameters.Add("Rating", product.Rating);
            parameters.Add("ReviewText", product.ReviewText);
            parameters.Add("ReviewDate", product.ReviewDate );

            connection.Execute(sql, parameters);
        }

        //get all product review - user
        public IEnumerable<ProductReview> GetProductReviews()
        {
            string sql = "SELECT * FROM ProductReview";

            return connection.Query<ProductReview>(sql);
        }

        //get product review by id - admin
        public ProductReview GetProductReviewById(Guid id)
        {
            string sql = "SELECT * FROM ProductReview WHERE Id = @id";

            return connection.QueryFirst<ProductReview>(sql);
        }

        //get product review by product id - user
        public IEnumerable<ProductReview> GetProductReviewByProductId(Guid id)
        {
            string sql = "SELECT * FROM ProductReview WHERE ProductId = @id";

            return connection.Query<ProductReview>(sql);
        }

        //get product review by user id - user
        public IEnumerable<ProductReview> GetProductReviewByUserId(Guid id)
        {
            string sql = "SELECT * FROM ProductReview WHERE Id = @id";

            return connection.Query<ProductReview>(sql);
        }

        //get product  review by rating - user
        public IEnumerable<ProductReview> GetProductReviewByRating(int rating)
        {
            string sql = "SELECT * FROM ProductReview WHERE Rating = @rating";

            return connection.Query<ProductReview>(sql);
        }

    }
}
