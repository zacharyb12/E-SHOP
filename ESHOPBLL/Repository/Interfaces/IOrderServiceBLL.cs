using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._08.Order;

namespace ESHOPBLL.Repository.Interfaces
{
    public interface IOrderServiceBLL
    {
        void CreateOrder(CreateOrder order);

        void UpdateOrder(Order order);

        public IEnumerable<Order> GetAllOrders();

        public IEnumerable<Order> GetOrderById(Guid id);

        IEnumerable<Order> GetOrderByUserId(Guid id);
    }
}