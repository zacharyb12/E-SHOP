using Dapper;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._03.Product;
using ESHOPDomainModels.Models.User;
using System.Data.SqlClient;

namespace ESHOPDAL.Repository.Services
{
    public class ProductServiceDAL : IProductServiceDAL
    {
        private SqlConnection connection;

        public ProductServiceDAL(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void CreateProduct(CreateProduct product)
        {
            Guid categoryId = GetCategoryIdByName(product.CategoryName);

            if (categoryId != Guid.Empty)
            {
               string sql = "INSERT INTO Product (Name, Price, ImagePath, Description, StockQuantity, Rating, CategoryId) " +
                "VALUES (@Name, @Price, @ImagePath, @Description, @StockQuantity, @Rating , @CategoryId)";
                

                var parameters = new DynamicParameters();
                parameters.Add("Name", product.Name);
                parameters.Add("Price", product.Price);
                parameters.Add("ImagePath", product.ImagePath);
                parameters.Add("Description", product.Description);
                parameters.Add("StockQuantity", product.StockQuantity);
                parameters.Add("Rating", product.Rating);
                parameters.Add("CategoryId", categoryId);

                connection.ExecuteScalar(sql, parameters);
            }
            else
            {
                throw new InvalidOperationException("Category not found");
            }
        }

        private Guid GetCategoryIdByName(string categoryName)
        {
            string sql = "SELECT Id FROM Category WHERE Name = @CategoryName";
            return connection.QueryFirstOrDefault<Guid>(sql, new { CategoryName = categoryName });
        }

        public IEnumerable<Product> GetProducts()
        {
            string sql = "SELECT Product.*, Category.Name AS CategoryName " +
                 "FROM Product " +
                 "JOIN Category ON Product.CategoryId = Category.Id";

            return connection.Query<Product>(sql);

        }

        public IEnumerable<Product> GetProductsByCategoryName(string name)
        {
            string sql = "SELECT Product.*, Category.Name AS CategoryName " +
                 "FROM Product " +
                 "JOIN Category ON Product.CategoryId = Category.Id " +
                 "WHERE CategoryName = @name ";

            var parameters = new DynamicParameters();
            parameters.Add("Name", name);

            return connection.Query<Product>(sql , parameters);

        }

        public Product GetById(Guid id)
        {
            string sql = "SELECT * FROM Product WHERE Id = @id";

            return connection.QueryFirst<Product>(sql, new { id });
        }

        public Product GetByName(string name)
        {
            string sql = "SELECT * FROM Product WHERE Name LIKE @name";

            return connection.QueryFirst<Product>(sql, new { name });
        }

        public void UpdateProductInfo(UpdateProduct product, string info, Guid id)
        {
            var validColumnNames = new List<string> { "Name", "Price", "ImagePath", "Description", "StockQuantity", "Rating" };

            if (!validColumnNames.Contains(info))
            {
                throw new ArgumentException("Nom de colonne non valide.", nameof(info));
            }

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            string sql = $"UPDATE Product SET {info} = @Value WHERE Id = @Id";

            // Utilisez la réflexion pour obtenir la valeur de la propriété
            object propertyValue = typeof(UpdateProduct).GetProperty(info)?.GetValue(product);

            parameters.Add("@Value", propertyValue);

            connection.ExecuteScalar(sql, parameters);
        }

    }
}
