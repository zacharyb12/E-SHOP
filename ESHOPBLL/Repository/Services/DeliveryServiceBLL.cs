using ESHOPBLL.Repository.Interfaces;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._10.Delivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPBLL.Repository.Services
{
    public class DeliveryServiceBLL : IDeliveryServiceBLL
    {
        public IDeliveryServiceDAL deliveryService;

        public DeliveryServiceBLL(IDeliveryServiceDAL deliveryService)
        {
            this.deliveryService = deliveryService;
        }

        public void CreateDelivery(CreateDelivery delivery)
        {
            deliveryService.CreateDelivery(delivery);
        }

        public IEnumerable<Delivery> GetAllDeliveries()
        {
            return deliveryService.GetAllDelivery();
        }

        public IEnumerable<Delivery> GetAllDeliveriesByStatus(string status)
        {
            return deliveryService.GetAllDeliveryByStatus(status);
        }

        public IEnumerable<Delivery> GetAllDeliveriesByUserId(Guid id)
        {
            return deliveryService.GetAllDeliveryUserId(id);
        }

        public Delivery GetById(Guid id)
        {
            return deliveryService.GetById(id);
        }
    }
}
