using Microsoft.EntityFrameworkCore;
using SantaPackageSystem.Application.Models;

namespace SantaPackageSystem.Infrastructure.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Elf> Elves { get; set; }
        public DbSet<Package> Packages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Elf>()
                .HasMany(e => e.Packages)
                .WithOne(p => p.AssignedElf)
                .HasForeignKey(p => p.AssignedElfId)
                .OnDelete(DeleteBehavior.SetNull);
        }

    }
}
