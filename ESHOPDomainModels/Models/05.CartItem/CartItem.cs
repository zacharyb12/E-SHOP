﻿namespace ESHOPDomainModels.Models.CartItem
{
    public class CartItem
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal ItemPrice { get; set; }
    }
}

