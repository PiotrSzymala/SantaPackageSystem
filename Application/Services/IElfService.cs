using SantaPackageSystem.Application.Models;
using SantaPackageSystem.Application.Models.DTO;

namespace SantaPackageSystem.Application.Services
{
    public interface IElfService
    {
        Task<GetElfDTO> GetElfById(long id);
        Task<Elf> HireNewElf(CreateElfDto newElfData);
        Task<bool> GrantParentalLeave(long elfId);
        Task<bool> RevokeParentalLeave(long elfId);
        Task<bool> GrantLeave(long elfId);
        Task<bool> RevokeLeave(long elfId);
    }
}
