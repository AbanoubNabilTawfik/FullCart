using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.DTO.Order
{
    public class GetOrderDto
    {
        public long Id { get; set; }
        public decimal TotalPrice { get; set; }
        public string StatusValue { get; set; }
        public List<OrderItem>? Items { get; set; }
        public string? userName { get; set; }
    }
}
