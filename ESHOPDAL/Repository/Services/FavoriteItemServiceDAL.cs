using Dapper;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPDAL.Repository.Services
{
    public class FavoriteItemServiceDAL : IFavoriteItemServiceDAL
    {
        private SqlConnection connection;

        public FavoriteItemServiceDAL(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void AddFavoriteItem(FavoriteItem favorite)
        {
            string sql = "INSERT INTO FavoriteItem (UserId , ProductId ) VALUES ( @UserId , @ProductId )";

            var parameters = new DynamicParameters();
            parameters.Add("UserId", favorite.UserId);
            parameters.Add("ProductId", favorite.ProductId);

            connection.Execute(sql, parameters);
        }

        public void DeleteFavoriteItem(FavoriteItem favorite)
        {
            string sql = "DELETE FROM FavoriteItem WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", favorite.Id);

            connection.Execute(sql, parameters);
        }

        public IEnumerable<FavoriteItem> GetFavoriteItemByUser(Guid id)
        {
            string sql = "SELECT * FROM FavoriteItem WHERE UserId = @id";

                var parameters = new DynamicParameters();
                parameters.Add("UserId", id);

            return connection.Query<FavoriteItem>(sql, parameters);
        }
    }
}
