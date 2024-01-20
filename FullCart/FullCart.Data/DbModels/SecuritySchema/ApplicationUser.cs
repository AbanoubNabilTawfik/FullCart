﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Data.DbModels.SecuritySchema
{
    public class ApplicationUser :IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public bool ChangePassword { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? CreatorUserID { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int AccountStatus { get; set; }
        public int UserRole { get; set; }
        public bool IsFirstLogin { get; set; } = true;
        public bool IsDeleted { get; set; }
    }
}
