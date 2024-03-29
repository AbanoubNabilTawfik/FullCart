﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Data.DbModels.FullCartSchema
{
    [Table("Category", Schema = "FullCart")]
    public class Category :BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string ?Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
    }
}
