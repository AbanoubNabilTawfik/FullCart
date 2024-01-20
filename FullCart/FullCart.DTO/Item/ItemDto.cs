using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.DTO.Item
{
    public class ItemDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int AvaliableQuantity { get; set; }
        public virtual IFormFile? Image { get; set; }
        public long BrandID { get; set; }
        public long CategoryID { get; set; }


    }
}
