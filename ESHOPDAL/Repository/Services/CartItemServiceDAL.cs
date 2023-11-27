using Dapper;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models.CartItem;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPDAL.Repository.Services
{
    public class CartItemServiceDAL : ICartItemServiceDAL
    {
        private SqlConnection connection;

        public CartItemServiceDAL(SqlConnection connection)
        {
            this.connection = connection;
        }

        //creation cartItem for user  - user
        public void CreateCartItem(CreateCartItem cartItem)
        {
            string sql = "INSERT INTO CartItem (UserId, ProductId, Quantity, ItemPrice) VALUES (@UserId, @ProductId, @Quantity, @ItemPrice)";

            var parameters = new DynamicParameters();
            parameters.Add("UserId", cartItem.UserId);
            parameters.Add("ProductId", cartItem.ProductId);
            parameters.Add("Quantity", cartItem.Quantity);
            parameters.Add("ItemPrice", cartItem.ItemPrice);

            connection.Execute(sql, parameters);
        }

        //get all cart item - user
        public IEnumerable<CartItem> GetCartItems(Guid id)
        {
            string sql = "SELECT * FROM CartItem WHERE UserId = @UserId";

            var parameters = new DynamicParameters();
            parameters.Add("UserId", id);

            return connection.Query<CartItem>(sql, parameters);
        }

        //change cart item if buy item - admin
        public void DeleteCartItem(Guid id)
        {
            string sql = " Update Status FROM CartItem  Where Id = @id ";

            connection.Execute(sql);
        }

        // modification of cart item - user
        public void UpdateCartItemInfo(CartItem cartItem, string info, Guid id)
        {
            string sql = $"UPDATE CartItem SET {info} = @Value WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            // Utilisez la réflexion pour obtenir la valeur de la propriété
            object? propertyValue = typeof(CartItem).GetProperty(info)?.GetValue(cartItem);
            parameters.Add("@Value", propertyValue);

            connection.Execute(sql, parameters);
        }

    }
}
