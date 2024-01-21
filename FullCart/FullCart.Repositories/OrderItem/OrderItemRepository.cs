using FullCart.Data.DbContexts;
using FullCart.Repositories.Generic;
using FullCart.Repositories.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Repositories.OrderItem
{
    public class OrderItemRepository : GenericRepository<Data.DbModels.FullCartSchema.OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
