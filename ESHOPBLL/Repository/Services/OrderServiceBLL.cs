using ESHOPBLL.Repository.Interfaces;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._08.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPBLL.Repository.Services
{
    public class OrderServiceBLL : IOrderServiceBLL
    {
        private readonly IOrderServiceDAL orderService;

        public OrderServiceBLL(IOrderServiceDAL orderService)
        {
            this.orderService = orderService;
        }

        public void CreateOrder(CreateOrder order)
        {
            orderService.CreateOrder(order);
        }

        public void UpdateOrder(Order order)
        {
            orderService.UpdateOrder(order);
        }

        public IEnumerable<Order> GetAllOrders() 
        {
            return orderService.GetOrders();
        }

        public IEnumerable<Order> GetOrderById(Guid id)
        {
            return orderService.GetOrderById(id);
        }

        public IEnumerable<Order> GetOrderByUserId(Guid id)
        {
            return orderService.GetOrderByUserId(id);
        }
    }
}
