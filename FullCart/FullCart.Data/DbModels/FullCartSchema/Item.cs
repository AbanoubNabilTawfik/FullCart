using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Data.DbModels.FullCartSchema
{
    [Table("Item", Schema = "FullCart")]
    public class Item :BaseEntity
    {
        public long Id { get; set; }
        public string ?Name { get; set; }
        public string ?Description { get; set; }
        public decimal Price { get; set; }
        public int AvaliableQuantity { get; set; }
        public string ?Image { get; set; }

        [ForeignKey("Brand")]
        public long BrandID { get; set; }
        public Brand? Brand { get; set; }

        [ForeignKey("Category")]
        public long CategoryID { get; set; }
        public Category? Category { get; set; }

    }
}
