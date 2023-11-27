using Dapper;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._07.OrderITem;
using ESHOPDomainModels.Models._08.Order;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPDAL.Repository.Services
{
    public class OrderServiceDAL : IOrderServiceDAL
    {
        SqlConnection connection;

        public OrderServiceDAL(SqlConnection connection)
        {
            this.connection = connection;
        }

        //create order - user
        public void CreateOrder(CreateOrder order)
        {
            string sql = "INSERT INTO Order (UserId , Status , OrderDate , TotalPrice) VALUES (@UserId , @Status , @OrderDate , @TotalPrice)";

            var parameters = new DynamicParameters();
            parameters.Add("UserId", order.UserId);
            parameters.Add("Status", order.Status);
            parameters.Add("OrderDate", order.OrderDate);
            parameters.Add("TotalPrice", order.TotalPrice);

            connection.Query(sql, parameters);
        }

        //update order 
        public void UpdateOrder(Order order)
        {
            string sql = "UPDATE Order SET Status = @status WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("UserId", order.Id);
            parameters.Add("Status", order.Status);

            connection.Execute(sql, parameters);
        }

        // get order by id - user
        public IEnumerable<Order> GetOrderById(Guid id) 
        {
            string sql = "SELECT * FROM Order WHERE Id = @id";

            return  connection.Query<Order>(sql, new[] { id });   

        }

        //get order by user id -  user
        public IEnumerable<Order> GetOrderByUserId(Guid id)
        {
            string sql = "SELECT * FROM Order WHERE UserId = @id";

            return connection.Query<Order>(sql, new[] { id });

        }

        // get all order - admin
        public IEnumerable<Order> GetOrders() 
        {
            string sql = " SELECT * FROM [Order] ";
            return connection.Query<Order>(sql);
        }

    }
}
