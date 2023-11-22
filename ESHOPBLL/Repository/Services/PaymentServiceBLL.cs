using ESHOPBLL.Repository.Interfaces;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._09.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPBLL.Repository.Services
{
    public class PaymentServiceBLL : IPaymentServiceBLL
    {
        private readonly IPaymentServiceDAL paymentService;

        public PaymentServiceBLL(IPaymentServiceDAL paymentService)
        {
            this.paymentService = paymentService;
        }

        public void CreatePayment(CreatePayment payment)
        {
            paymentService.CreatePayment(payment);
        }

        public IEnumerable<Payment> GetAllPayment()
        {
            return paymentService.GetAllPayment();
        }

        public Payment GetPaymentById(Guid id)
        {
            return paymentService.GetPaymentById(id);
        }

        public Payment GetPaymentByUserId(Guid id)
        {
            return paymentService.GetPaymentByUserId(id);
        }

        public void UpdatePayment(Guid id)
        {
            if (GetPaymentById(id) == null) 
            {
                throw new Exception("Id doesn't exist");
            }
            Payment payment  = GetPaymentById(id);
            paymentService.UpdatePayment(payment);
        }
    }
}
