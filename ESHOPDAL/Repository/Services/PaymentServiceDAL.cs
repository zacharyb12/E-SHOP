using Dapper;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._09.Payment;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPDAL.Repository.Services
{
    public class PaymentServiceDAL : IPaymentServiceDAL
    {
        private SqlConnection connection;

        public PaymentServiceDAL(SqlConnection connection)
        {
            this.connection = connection;
        }

        // create payment for delivery - user
        public void CreatePayment(CreatePayment payment)
        {
            string sql = "INSERT INTO Payment (OrderId , UserId , Amount , PaymentDate , PaymentValidation ) VALUES ( @OrderId , @UserId , @Amount , @PaymentDate , @PaymentValidation) ";

            var parameters = new DynamicParameters();
            parameters.Add("OrderId", payment.OrderId);
            parameters.Add("UserId", payment.UserId);
            parameters.Add("Amount", payment.Amount);
            parameters.Add("PaymentDate", payment.PaymentDate);
            parameters.Add("PaymentValidation", payment.PaymentValidation);

            connection.Execute(sql, parameters);
        }

        // update payment value ( confirmation) - user
        public void UpdatePayment(Payment payment)
        {
            string sql = " UPDATES Payment SET Status = @payment.Status WHERE ID = @payment.Id ";

            var parameters = new DynamicParameters();
            parameters.Add("Id", payment.Id);
            parameters.Add("PaymentValidation", payment.PaymentValidation);

            connection.Execute(sql, parameters);
        }

        //get payment by id - admin
        public Payment GetPaymentById(Guid id)
        {
            string sql = "SELECT * FROM Payment WHERE ID = @id";

            return connection.ExecuteScalar<Payment>(sql);
        }

        //get payment by user id - user
        public Payment GetPaymentByUserId(Guid id)
        {
            string sql = "SELECT * FROM Payment WHERE UserId = @id";

            return connection.ExecuteScalar<Payment>(sql);
        }

        // get all payment - admin
        public IEnumerable<Payment> GetAllPayment()
        {
            string sql = "SELECT * FROM Payment";

            return connection.Query<Payment>(sql);
        }

    }
}
