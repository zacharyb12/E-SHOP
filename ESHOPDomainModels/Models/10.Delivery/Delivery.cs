namespace ESHOPDomainModels.Models
{
    public class Delivery
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid OrderId { get; set; }

        public string Status { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}
