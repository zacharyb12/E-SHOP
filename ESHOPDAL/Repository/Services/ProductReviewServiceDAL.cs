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

        public void CreateProductReview(ProductReviewDate product)
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

        public IEnumerable<ProductReview> GetProductReviews()
        {
            string sql = "SELECT * FROM ProductReview";

            return connection.Query<ProductReview>(sql);
        }

        public ProductReview GetProductReviewById(Guid id)
        {
            string sql = "SELECT * FROM ProductReview WHERE Id = @id";

            return connection.QueryFirst<ProductReview>(sql);
        }

        public IEnumerable<ProductReview> GetProductReviewByUserId(Guid id)
        {
            string sql = "SELECT * FROM ProductReview WHERE Id = @id";

            return connection.Query<ProductReview>(sql);
        }

        public IEnumerable<ProductReview> GetProductReviewByRating(int rating)
        {
            string sql = "SELECT * FROM ProductReview WHERE Rating = @rating";

            return connection.Query<ProductReview>(sql);
        }
    }
}
