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

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Status { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public virtual ICollection<Guid> CartItems { get; set; }

        public virtual ICollection<Guid> Orders { get; set; }

        public virtual ICollection<Guid> Payments { get; set; }

        public virtual ICollection<Guid> ProductsReview { get; set; }

    }
}
