using FullCart.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Repositories.OrderItem
{
    public interface IOrderItemRepository : IGenericRepository<Data.DbModels.FullCartSchema.OrderItem>
    {
    }
}
