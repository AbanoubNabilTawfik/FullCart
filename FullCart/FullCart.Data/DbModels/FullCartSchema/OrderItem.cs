using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Data.DbModels.FullCartSchema
{
    [Table("OrderItem", Schema = "FullCart")]
    public class OrderItem:BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

       // [ForeignKey("Order")]
        public long OrderId { get; set; }
        public Order Order { get; set; }

       // [ForeignKey("Item")]
        public long ItemId { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }
}
