using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._08.Order;

namespace ESHOPDAL.Repository.Interfaces
{
    public interface IOrderServiceDAL
    {
        void CreateOrder(CreateOrder order);

        void UpdateOrder(Order order);

        IEnumerable<Order> GetOrderById(Guid id);

        IEnumerable<Order> GetOrderByUserId(Guid id);

        IEnumerable<Order> GetOrders();
    }
}