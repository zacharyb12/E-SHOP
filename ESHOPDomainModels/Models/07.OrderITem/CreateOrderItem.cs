using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPDomainModels.Models._07.OrderITem
{
    public class CreateOrderItem
    {
        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal ItemPrice { get; set; }
    }
}
