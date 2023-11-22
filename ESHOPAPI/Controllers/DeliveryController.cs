using ESHOPBLL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._10.Delivery;
using Microsoft.AspNetCore.Mvc;

namespace ESHOPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        public IDeliveryServiceBLL deliveryService;

        public DeliveryController(IDeliveryServiceBLL deliveryService)
        {
            this.deliveryService = deliveryService;
        }

        [HttpPost]
        public IActionResult CreateDelivery(CreateDelivery delivery)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            deliveryService.CreateDelivery(delivery);
            return Ok(ModelState);
        }

        [HttpGet]
        public IEnumerable<Delivery> GetDeliveries() 
        {
            return deliveryService.GetAllDeliveries();
        }

        [HttpGet("Id")]
        public Delivery  GetDeliveryById(Guid id)
        {
            return deliveryService.GetById(id);
        }

        [HttpGet("UserId")]
        public IEnumerable<Delivery> GetDeliveriesByUserId(Guid id)
        {
            return deliveryService.GetAllDeliveriesByUserId(id);
        }

        [HttpGet("Status")]
        public IEnumerable<Delivery> GetDeliveriesByStatus(string status)
        {
            return deliveryService.GetAllDeliveriesByStatus(status);
        }

    }
}
