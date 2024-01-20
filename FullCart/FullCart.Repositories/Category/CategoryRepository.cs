using FullCart.Data.DbContexts;
using FullCart.Repositories.Generic;
using FullCart.Repositories.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Repositories.Category
{
    public class CategoryRepository : GenericRepository<Data.DbModels.FullCartSchema.Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
