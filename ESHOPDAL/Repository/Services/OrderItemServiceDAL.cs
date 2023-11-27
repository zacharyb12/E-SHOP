using Dapper;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._07.OrderITem;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPDAL.Repository.Services
{
    public class OrderItemServiceDAL : IOrderItemServiceDAL
    {
        private SqlConnection connection;

        public OrderItemServiceDAL(SqlConnection connection)
        {
            this.connection = connection;
        }

        //create  orderItem for order - user
         public void CreateOrderItem(CreateOrderItem orderItem)
        {
            string sql = "INSERT INTO OrderItem (OrderID , ProductId , Quantity , ItemPrice) VALUES (@OrderID , @ProductId , @Quantity , @ItemPrice)";

            var parameters = new DynamicParameters();
            parameters.Add("OrderId", orderItem.OrderId);
            parameters.Add("ProductId", orderItem.OrderId);
            parameters.Add("Quantity", orderItem.Quantity);
            parameters.Add("ItemPrice", orderItem.ItemPrice);

            connection.Execute(sql, parameters);
        }

        // get all order by user id - user
        public IEnumerable<OrderItem> GetAllOrdersUserId(Guid id) 
        {
            string sql = "SELECT * FROM OrderITem WHERE UserId = @id";

            return connection.Query<OrderItem>(sql);
        }

        //get all order - admin
        public IEnumerable<OrderItem> GetAllOrders()
        {
            string sql = "SELECT * FROM OrderITem";

            return connection.Query<OrderItem>(sql);
        }

        //delete order for delivery 
        public void DeleteOrderITem(Guid id)
        {

        }
    }
}
