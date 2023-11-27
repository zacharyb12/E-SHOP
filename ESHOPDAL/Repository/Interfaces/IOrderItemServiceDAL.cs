using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._07.OrderITem;

namespace ESHOPDAL.Repository.Interfaces
{
    public interface IOrderItemServiceDAL
    {

        void CreateOrderItem(CreateOrderItem orderItem);

        IEnumerable<OrderItem> GetAllOrdersUserId(Guid id);

        IEnumerable<OrderItem> GetAllOrders();

        //void DeleteOrderITem(Guid id);

    }
}