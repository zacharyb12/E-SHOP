using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPDomainModels.Models._04.ProductReview
{
    public class CreateProductReview
    {
        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }

        public int Rating { get; set; }

        public string ReviewText { get; set; }

    }
}
