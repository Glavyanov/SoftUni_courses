using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebShopDemo.Core.Data.Models;
using WebShopDemo.Core.Data.Models.Accounts;

namespace WebShopDemo.Core.Data
{
    public class ApplicationDemoDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDemoDbContext(DbContextOptions<ApplicationDemoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
    }
}