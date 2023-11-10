namespace ESHOPDomainModels.Models
{
    public class ProductReview
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }

        public int Rating { get; set; }

        public string ReviewText { get; set; }

        public DateTime ReviewDate { get; set; }
    }
}
