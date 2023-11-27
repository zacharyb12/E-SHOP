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

        //Create new category with a name - admin
        public void CreateCategory(CreateCategory category)
        {
            string sql = "INSERT INTO Category (Name) VALUES (@name)";

            var parameters = new DynamicParameters();
            parameters.Add("@Name", category.Name);


            connection.Execute(sql, parameters );
        }

        //get all categories - user
        public IEnumerable<Category> GetCategories()
        {
            string sql = " SELECT * FROM Category";

            return connection.Query<Category>(sql);
        }

        //get a category with id  - admin
        public Category GetCategoryById(Guid id)
        {
            return connection.QueryFirst<Category>(" SELECT * FROM Category WHERE Id = @id ", new {id} );
        } 

        //get a category by name - user
        public Category GetCategoryByName(string name)
        {
            return connection.QueryFirst<Category>("SELECT * FROM Category WHERE Name = @name", new { name });
        }

        // update category name - admin
        public void UpdateCategory(Category category , Guid id)
        {
            string sql = "UPDATE Category SET Name = @name WHERE Id = @id ";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", category.Name);
            parameters.Add("@Id" , id);

            connection.Execute(sql, parameters);
        }

        //delete a category - admin
        public void DeleteCategory(Guid id)
        {
            string sql = "DROP * FROM Category WHERE Id = @id";

            connection.Execute(sql, new {id});
        }

    }
}
