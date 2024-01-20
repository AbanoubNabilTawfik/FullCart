using FullCart.Data.DbModels.SecuritySchema;
using FullCart.Data.DbModels.UserSchema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Data.DbModels.FullCartSchema
{
    [Table("Order", Schema = "FullCart")]
    public class Order :BaseEntity
    {
        public long Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int Status { get; set; }
        public ICollection<Item> ?Items { get; set; }

        [ForeignKey("User")]
        public string? UserID { get; set; }
        public User? User { get; set; }

    }
}
