using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._10.Delivery;

namespace ESHOPBLL.Repository.Interfaces
{
    public interface IDeliveryServiceBLL
    {
        void CreateDelivery(CreateDelivery delivery);
        IEnumerable<Delivery> GetAllDeliveries();
        IEnumerable<Delivery> GetAllDeliveriesByStatus(string status);
        IEnumerable<Delivery> GetAllDeliveriesByUserId(Guid id);
        Delivery GetById(Guid id);
    }
}