using ESHOPBLL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._08.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESHOPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceBLL orderService;

        public OrderController(IOrderServiceBLL orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<Order> GetOrders() 
        {
            return orderService.GetAllOrders();
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrder order) 
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }
             orderService.CreateOrder(order);
            return Ok(ModelState);

        }

        [HttpPost("Update")]
        public IActionResult UpdateOrder(Order order) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            orderService.UpdateOrder(order);
            return Ok(ModelState);
        }

        [HttpGet("Id")]
        public IEnumerable<Order> GetById(Guid id) 
        {
            if (!ModelState.IsValid) 
            {
                return Enumerable.Empty<Order>();
            }
            return orderService.GetOrderById(id);
        }

        [HttpGet("UserId")]
        public IEnumerable<Order> GetByUserId(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return Enumerable.Empty<Order>();
            }
            return orderService.GetOrderByUserId(id);
        }

    }
}
