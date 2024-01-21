using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.DTO.Order
{
    public class OrderDto
    {
        public decimal TotalPrice { get; set; }
        public string StatusValue { get; set; }
        public List<OrderItem>? Items { get; set; }
        public string? userName { get; set; }

    }
}
