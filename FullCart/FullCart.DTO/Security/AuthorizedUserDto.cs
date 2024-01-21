using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.DTO.Security
{
    public class AuthorizedUserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CallingCode { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool ChangePassword { get; set; }
        public int? RoleId { get; set; }
        public string Status { get; set; } 
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public bool EmailConfirmed { get; set; }

        public string Role { get; set; }

    }
}
