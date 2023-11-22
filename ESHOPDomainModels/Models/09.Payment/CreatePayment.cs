using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPDomainModels.Models._09.Payment
{
    public class CreatePayment
    {
        public Guid OrderId { get; set; }

        public Guid UserId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; }

        public string PaymentValidation { get; set; }
    }
}
