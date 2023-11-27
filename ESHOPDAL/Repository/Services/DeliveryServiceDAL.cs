using Dapper;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._10.Delivery;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPDAL.Repository.Services
{
    public class DeliveryServiceDAL : IDeliveryServiceDAL
    {
        private readonly SqlConnection connection;

        public DeliveryServiceDAL(SqlConnection connection)
        {
            this.connection = connection;
        }

        //Create a delivery from cartItem - user
        public void CreateDelivery(CreateDelivery delivery)
        {
            string sql = "INSERT INTO Delivery  (UserId , OrderId , Status , DeliveryDate ) VALUES (@UserId , @OrderId , @Status , @DeliveryDate)";

            var parameters = new DynamicParameters();
            parameters.Add("UserId", delivery.UserId);
            parameters.Add("OrderId", delivery.OrderId);
            parameters.Add("Status", delivery.Status);
            parameters.Add("DeliveryDate", delivery.DeliveryDate);

            connection.Execute(sql, parameters);
        }

        //get all delivery - admin
        public IEnumerable<Delivery> GetAllDelivery()
        {
            string sql = " SELECT * FROM Delivery";

            return connection.Query<Delivery>(sql);
        }

        // get delivery by id - user
        public Delivery GetById(Guid id)
        {
            string sql = "Select * FROM Delivery WHERE Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);

            return connection.QueryFirst<Delivery>(sql, parameters);
        }

        // get delivery by USer Id - user
        public IEnumerable<Delivery> GetAllDeliveryUserId(Guid id)
        {
            string sql = " SELECT * FROM Delivery WHERE UserId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", id);

            return connection.Query<Delivery>(sql, parameters);
        }

        //get all delivery by status - admin
        public IEnumerable<Delivery> GetAllDeliveryByStatus(string status)
        {
            string sql = " SELECT * FROM Delivery WHERE Status = @status";
            var parameters = new DynamicParameters();
            parameters.Add("Status", status);

            return connection.Query<Delivery>(sql, parameters);
        }

    }
}
