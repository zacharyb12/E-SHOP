using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._09.Payment;

namespace ESHOPBLL.Repository.Interfaces
{
    public interface IPaymentServiceBLL
    {

        void CreatePayment(CreatePayment payment);

        IEnumerable<Payment> GetAllPayment();

        Payment GetPaymentById(Guid id);

        Payment GetPaymentByUserId(Guid id);

        void UpdatePayment(Guid id);

    }
}