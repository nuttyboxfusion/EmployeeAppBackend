using EmployeeAppBackend.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAppBackend.Data
{
    public class EmployeeAppDbContext : DbContext
    {
        public EmployeeAppDbContext(DbContextOptions<EmployeeAppDbContext> options) : base(options)
        {
           
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring the owned type for Address
            modelBuilder.Entity<Employee>()
                .OwnsOne(e => e.Address);

            // Configuring the one-to-many relationship between Employee and Skill
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Skills)
                .WithOne(s => s.Employee)
                .HasForeignKey(s => s.EmployeeId);
        }
    }
}
