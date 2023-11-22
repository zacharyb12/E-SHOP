using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPDomainModels.Models._10.Delivery
{
    public  class CreateDelivery
    {
        public Guid UserId { get; set; }

        public Guid OrderId { get; set; }

        public string Status { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}
