using SantaPackageSystem.Application.Models;
using SantaPackageSystem.Application.Models.DTO;

namespace SantaPackageSystem.Application.Services
{
    public interface IPackageService
    {
        Task<Package> GetPackage(long packageId);
        Task<Package> CreatePackage(CreatePackageDTO newPackageData);
        Task<bool> AssignPackageToElf(int packageId, int elfId);
    }
}
