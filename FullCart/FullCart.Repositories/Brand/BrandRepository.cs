using FullCart.Data.DbContexts;
using FullCart.Repositories.Category;
using FullCart.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Repositories.Brand
{
    public class BrandRepository : GenericRepository<Data.DbModels.FullCartSchema.Brand>, IBrandRepository
    {
        public BrandRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
