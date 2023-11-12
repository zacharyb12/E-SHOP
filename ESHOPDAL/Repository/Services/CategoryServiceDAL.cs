using Dapper;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._02.Category;
using ESHOPDomainModels.Models.User;
using System.Data.SqlClient;
using System.Text;

namespace ESHOPDAL.Repository.Services
{
    public class CategoryServiceDAL : ICategoryServiceDAL
    {
        private SqlConnection connection;

        public CategoryServiceDAL(SqlConnection connection)
        {
            this.connection = connection;
        }

        //METHODES
        public void CreateCategory(CreateCategory category)
        {
            string sql = "INSERT INTO Category (Name) VALUES (@name)";

            var parameters = new DynamicParameters();
            parameters.Add("@Name", category.Name);


            connection.Execute(sql, parameters );
        }


        public IEnumerable<Category> GetCategories()
        {
            string sql = " SELECT * FROM Category";

            return connection.Query<Category>(sql);
        }


        public Category GetCategoryByName(string name)
        {

            return connection.QueryFirst<Category>(" SELECT * FROM Category WHERE Name = @name ", new { name });
        }

        public void UpdateCategory(Category category)
        {
            string sql = "UPDATE Category SET Name = @name WHERE Id = @id ";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", category.Name);
            parameters.Add("@Id" , category.Id);

            connection.Execute(sql, parameters);
        }
    }
}
