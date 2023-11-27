using ESHOPBLL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._07.OrderITem;
using Microsoft.AspNetCore.Mvc;

namespace ESHOPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderITemController : ControllerBase
    {
        private IOrderItemServiceBLL orderItemService;

        public OrderITemController(IOrderItemServiceBLL orderItemService)
        {
            this.orderItemService = orderItemService;
        }

        [HttpPost]
        public IActionResult CreateCartITem(CreateOrderItem orderItem)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }
            orderItemService.CreateOrderITem(orderItem);
            return Ok(ModelState);
        }

        [HttpGet]
        public IEnumerable<OrderItem> GetOrderItems() 
        {
            return orderItemService.GetAllOrders();
        }

        [HttpGet("Id")]
        public IEnumerable<OrderItem> GetAllOrdersUSerId(Guid id) 
        {
            return orderItemService.GetAllOrdersUserId(id);
        }

        [HttpPost("Delete")]
        public IActionResult DeleteOrderITem(Guid id)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }
            return Ok();
        }

    }
}
