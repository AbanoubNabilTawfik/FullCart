using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Data.DbModels
{
    public class BaseEntity
    {
        public DateTime? LMD { get; set; }
        public bool IsDeleted { get; set; }
    }
}
