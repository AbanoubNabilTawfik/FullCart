using FullCart.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Repositories.Item
{
    public interface IItemRepository : IGenericRepository<Data.DbModels.FullCartSchema.Item>
    {

    }
}
