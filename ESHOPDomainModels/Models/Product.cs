namespace ESHOPDomainModels.Models
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

        public Guid CategoryId { get; set; }
    }
}
