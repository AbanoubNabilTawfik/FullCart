using FullCart.Core.Enums;
using FullCart.Data.DbModels.SecuritySchema;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Data.DbContexts
{
    public class DataSeedingIntialization
    {
        private static AppDbContext _dbContext = null!;
        public static string[] AppAdminUserRolesNames = Enum.GetNames(typeof(EnUserRoles));

        public static void SeedAppData(AppDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();

            _dbContext = dbContext;

            SeedAdminApplicationRoles();
          

            if (dbContext.Users.Any()) return;
           
            _dbContext.SaveChanges();
        }
        private static void SeedAdminApplicationRoles()
        {
            //Seeding Roles
            var applicationRoles = _dbContext.Roles.ToList();
            if (applicationRoles == null || applicationRoles.Count == 0)
            {
                for (int i = 0; i < AppAdminUserRolesNames.Length; i++)
                {
                    _dbContext.Roles.Add(new IdentityRole()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = AppAdminUserRolesNames[i],
                        NormalizedName = AppAdminUserRolesNames[i].ToUpper()
                    });
                }
            }
            else
            {
                for (int i = 0; i < AppAdminUserRolesNames.Length; i++)
                {
                    var role = applicationRoles.FirstOrDefault(r => r.Name == AppAdminUserRolesNames[i]);
                    if (role == null)
                    {
                        _dbContext.Roles.Add(new IdentityRole()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = AppAdminUserRolesNames[i],
                            NormalizedName = AppAdminUserRolesNames[i].ToUpper()
                        });
                    }
                }
            }
            _dbContext.SaveChanges();
        }
    }
}
