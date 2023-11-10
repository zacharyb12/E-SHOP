namespace ESHOPDomainModels.Models
{
    public class Payment
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Guid UserId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; }

        public string PaymentValidation { get; set; }

    }
}
