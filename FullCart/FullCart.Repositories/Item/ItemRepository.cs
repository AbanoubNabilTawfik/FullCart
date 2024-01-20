using FullCart.Data.DbContexts;
using FullCart.Repositories.Generic;
using FullCart.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Repositories.Item
{
    public class ItemRepository : GenericRepository<Data.DbModels.FullCartSchema.Item>, IItemRepository
    {
        public ItemRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
