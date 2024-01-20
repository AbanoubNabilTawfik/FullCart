using FullCart.Data.DbContexts;
using FullCart.Repositories.Generic;
using FullCart.Repositories.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Repositories.Order
{
    public class OrderRepository : GenericRepository<Data.DbModels.FullCartSchema.Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
