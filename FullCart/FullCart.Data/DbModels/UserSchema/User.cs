using FullCart.Data.DbModels.FullCartSchema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Data.DbModels.UserSchema
{
    [Table("User", Schema = "User")]
    public class User :BaseEntity
    {
        public long ID { get; set; }
        public int Status { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Order>? CustomerOrders { get; set; }
    }
}
