using ESHOPBLL.Repository.Interfaces;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._07.OrderITem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPBLL.Repository.Services
{
    public class OrderItemServiceBLL : IOrderItemServiceBLL
    {
        private IOrderItemServiceDAL orderItemService;

        public OrderItemServiceBLL(IOrderItemServiceDAL orderItemService)
        {
            this.orderItemService = orderItemService;
        }

        public void CreateOrderITem(CreateOrderItem orderItem)
        {
            orderItemService.CreateOrderItem(orderItem);
        }


       public  IEnumerable<OrderItem> GetAllOrdersUserId(Guid id)
        {
            return orderItemService.GetAllOrdersUserId(id);
        }


        public IEnumerable<OrderItem> GetAllOrders()
        {
            return orderItemService.GetAllOrders();
        }


        public void DeleteOrderItem()
        {

        }

    }
}
