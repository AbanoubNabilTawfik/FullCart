using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Data.DbModels.FullCartSchema
{
    [Table("Brand", Schema = "FullCart")]
    public class Brand :BaseEntity
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
    }
}
