using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.DTO.Security
{
    public class RegisterDto
    {
        public string ?FirstName { get; set; }
        public string ?LastName { get; set; }
        public string ?Address { get; set; }
        public string ?PersonalImagePath { get; set; }
        public string ?Status { get; set; } // Active, NotActive, Locked
        public string? Email { get; set; }
        public string ?Password { get; set; }
        public string ?PhoneNumber { get; set; }

        public bool IsAdmin { get; set; }

        public virtual IFormFile? file { get; set; }
    }
}
