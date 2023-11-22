using ESHOPDomainModels.Models._11.EnumStatus;
using System.ComponentModel.DataAnnotations;

namespace ESHOPDomainModels.Models.User
{
    public class User
    {
        public Guid Id { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public UserStatus Status { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        //public virtual ICollection<CartItem> CartItems { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }

        //public virtual ICollection<Payment> Payments { get; set; }

        //public virtual ICollection<ProductReview> ProductsReview { get; set; }

    }
}
