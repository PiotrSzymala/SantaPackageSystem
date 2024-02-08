using Microsoft.EntityFrameworkCore;
using SantaPackageSystem.Models;

namespace SantaPackageSystem
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Elf> Elves { get; set; }
        public DbSet<Package> Packages { get; set; }
    }
}
