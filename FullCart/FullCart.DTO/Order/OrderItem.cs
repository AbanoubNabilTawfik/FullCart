using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.DTO.Order
{
    public class OrderItem
    {
        public long ItemId { get; set; }
        public int ItemQuantity { get; set; }
        public decimal ItemPrice { get; set; }

        public string ? ItemName { get; set; }
    }
}
