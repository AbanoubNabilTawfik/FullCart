using FullCart.Data.DbContexts;
using FullCart.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Repositories.User
{
    public class UserRepository : GenericRepository<Data.DbModels.UserSchema.User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
