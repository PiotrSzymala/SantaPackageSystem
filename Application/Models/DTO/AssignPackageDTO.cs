namespace SantaPackageSystem.Application.Models.DTO;

public record AssignPackageDTO
{
    public int PackageId { get; init; }
    public int ElfId { get; init; }
}