using Microsoft.EntityFrameworkCore;
using SantaPackageSystem.Application.Models;
using SantaPackageSystem.Application.Models.DTO;
using SantaPackageSystem.Infrastructure.Repository;

namespace SantaPackageSystem.Application.Services
{
    public class PackageService : IPackageService
    {
        private readonly ApplicationDbContext _context;
        public PackageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Package> GetPackage(long packageId)
        {
            var package = await _context.Packages.FirstOrDefaultAsync(x => x.Id == packageId);

            return package;
        }

        public async Task<Package> CreatePackage(CreatePackageDTO newPackageData)
        {
            var package = new Package()
            {
                PackageName = newPackageData.PackageName,
                Description = newPackageData.Description,
            };

            await _context.Packages.AddAsync(package);
            await _context.SaveChangesAsync();

            return package;
        }

        public async Task<bool> AssignPackageToElf(int packageId, int elfId)
        {
            var package = await _context.Packages.FindAsync(packageId);

            if (package == null || !await _context.Elves.AnyAsync(e => e.Id == elfId))
                return false;

            var elf = await _context.Elves.FirstOrDefaultAsync(e => e.Id == elfId);

            elf.Packages.Add(package);
            package.AssignedElfId = elfId;


            _context.Packages.Update(package);
            _context.Elves.Update(elf);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
