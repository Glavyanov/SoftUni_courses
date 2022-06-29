using ExerciseORM.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseORM.Data
{
    public class ExerciseDBContext : DbContext
    {
        public ExerciseDBContext()
        {

        }

        public ExerciseDBContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }
    }
}
