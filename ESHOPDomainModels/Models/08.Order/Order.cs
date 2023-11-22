namespace ESHOPDomainModels.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid OrderItemId { get; set; }

        public string Status { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
