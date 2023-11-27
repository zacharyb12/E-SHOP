using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPDomainModels.Models._08.Order
{
    public class CreateOrder
    {
        public Guid UserId { get; set; }

        public string Status { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
