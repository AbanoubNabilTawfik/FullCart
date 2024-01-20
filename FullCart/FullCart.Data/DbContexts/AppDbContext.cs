using FullCart.Data.DbModels.FullCartSchema;
using FullCart.Data.DbModels.SecuritySchema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Data.DbContexts
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #region FullCart
        public virtual DbSet<Brand>? Brands { get; set; }
        public virtual DbSet<Category>? Categories { get; set; }
        public virtual DbSet<Item>? Items { get; set; }
        public virtual DbSet<Order>? Orders { get; set; }

        #endregion
    }
}
