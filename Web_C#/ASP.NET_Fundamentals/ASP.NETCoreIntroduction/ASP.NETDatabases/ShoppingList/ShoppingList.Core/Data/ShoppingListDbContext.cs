namespace ShoppingList.Core.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using ShoppingList.Core.Models;

    public class ShoppingListDbContext : IdentityDbContext
    {
        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductNote> ProductsNotes { get; set; }

    }
}