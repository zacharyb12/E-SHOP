using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPDomainModels.Models._03.Product
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        public int StockQuantity { get; set; }

        public int Rating { get; set; }

        public string CategoryName { get; set; }
    }
}
