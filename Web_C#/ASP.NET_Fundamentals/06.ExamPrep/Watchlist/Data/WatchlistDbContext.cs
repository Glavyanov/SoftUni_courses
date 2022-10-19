using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Watchlist.Data.Entities;
using static Watchlist.Data.ValidationConstants.UserConstants;

namespace Watchlist.Data
{
    public class WatchlistDbContext : IdentityDbContext<User>
    {
        public WatchlistDbContext(DbContextOptions<WatchlistDbContext> options)
            : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<UserMovie> UsersMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserMovie>()
                .HasKey(k => new { k.UserId, k.MovieId });


             builder
                 .Entity<Genre>()
                 .HasData(new Genre()
                 {
                     Id = 1,
                     Name = "Action"
                 },
                 new Genre()
                 {
                     Id = 2,
                     Name = "Comedy"
                 },
                 new Genre()
                 {
                     Id = 3,
                     Name = "Drama"
                 },
                 new Genre()
                 {
                     Id = 4,
                     Name = "Horror"
                 },
                 new Genre()
                 {
                     Id = 5,
                     Name = "Romantic"
                 });
            
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .Property<string>(p => p.UserName)
                .HasMaxLength(NameMaxLength)
                .IsRequired();

            builder.Entity<User>()
                .Property<string>(p => p.Email)
                .HasMaxLength(EmailMaxLength)
                .IsRequired();
        }
    }
}