using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._07.OrderITem;

namespace ESHOPBLL.Repository.Interfaces
{
    public interface IOrderItemServiceBLL
    {
        void CreateOrderITem(CreateOrderItem orderItem);

        IEnumerable<OrderItem> GetAllOrdersUserId(Guid id);

        IEnumerable<OrderItem> GetAllOrders();

        void DeleteOrderItem();
    }
}