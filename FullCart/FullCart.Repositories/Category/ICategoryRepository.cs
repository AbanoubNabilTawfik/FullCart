using FullCart.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Repositories.Category
{
    public interface ICategoryRepository : IGenericRepository<Data.DbModels.FullCartSchema.Category>
    {
    }
}
