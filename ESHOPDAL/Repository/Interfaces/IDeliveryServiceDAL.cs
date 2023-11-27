using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._10.Delivery;

namespace ESHOPDAL.Repository.Interfaces
{
    public interface IDeliveryServiceDAL
    {

        void CreateDelivery(CreateDelivery delivery);

        IEnumerable<Delivery> GetAllDelivery();

        IEnumerable<Delivery> GetAllDeliveryByStatus(string status);

        IEnumerable<Delivery> GetAllDeliveryUserId(Guid id);

        Delivery GetById(Guid id);

    }
}