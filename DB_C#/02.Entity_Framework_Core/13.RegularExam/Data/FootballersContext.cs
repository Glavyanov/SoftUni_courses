namespace Footballers.Data
{
    using Footballers.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class FootballersContext : DbContext
    {
        public FootballersContext() { }

        public FootballersContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Footballer> Footballers { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        public DbSet<TeamFootballer> TeamsFootballers { get; set; }

        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamFootballer>(tf =>
            {
                tf.HasKey(k => new { k.TeamId, k.FootballerId });
            });
        }
    }
}
