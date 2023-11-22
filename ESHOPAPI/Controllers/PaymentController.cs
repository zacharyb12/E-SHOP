using ESHOPBLL.Repository.Interfaces;
using ESHOPDomainModels.Models;
using ESHOPDomainModels.Models._09.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESHOPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServiceBLL paymentService;

        public PaymentController(IPaymentServiceBLL paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpGet]
        public IEnumerable<Payment> GetAllPayments() 
        {  
            return paymentService.GetAllPayment();
        }

        [HttpGet("Id")]
        public Payment GetPaymentById(Guid id) 
        {
            return paymentService.GetPaymentById(id);
        }

        [HttpGet("UserId")]
        public Payment GetPaymentByUserId(Guid id)
        {
            return paymentService.GetPaymentByUserId(id);
        }

        [HttpPost]
        public void CreatePayment(CreatePayment payment) 
        { 
            if(payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }
            paymentService.CreatePayment(payment);
        }

        [HttpPost("Update")]
        public void UpdatePayment(Guid id)
        {
            paymentService.UpdatePayment(id);
        }
    }
}
