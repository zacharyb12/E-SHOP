using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._09.Payment;

namespace ESHOPDAL.Repository.Interfaces
{
    public interface IPaymentServiceDAL
    {
        void CreatePayment(CreatePayment payment);

        IEnumerable<Payment> GetAllPayment();

        Payment GetPaymentById(Guid id);

        Payment GetPaymentByUserId(Guid id);

        void UpdatePayment(Payment payment);
    }
}