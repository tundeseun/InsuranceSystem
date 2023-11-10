using Microsoft.EntityFrameworkCore;

namespace InsuranceSystem.Models
{
    public class InsuranceDbContext : DbContext
    {
        public DbSet<Policyholder> Policyholders { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Expense entity
            modelBuilder.Entity<Expense>()
                .Property(e => e.Amount)
                .HasColumnType("decimal(18,2)"); // Adjust precision and scale as needed

            // Configure Claim entity
            modelBuilder.Entity<Claim>()
                .Property(c => c.TotalClaimAmount)
                .HasColumnType("decimal(18,2)"); // Adjust precision and scale as needed

            // Configure relationships, constraints, etc.
            // Example:
            modelBuilder.Entity<Policyholder>()
                .HasMany(p => p.Claims)
                .WithOne(c => c.Policyholder);

            // Other configurations...

            base.OnModelCreating(modelBuilder);
        }
    }
}
