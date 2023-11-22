using ESHOPDomainModels.Models._11.EnumStatus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOPDomainModels.Models.User
{
    public class CreateUser
    {
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        public UserStatus Status { get; set; } = UserStatus.User;

        [StringLength(255)]
        public string Address { get; set; }
    }
}
