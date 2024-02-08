namespace SantaPackageSystem.Application.Models.DTO
{
    public record CreatePackageDTO
    {
        public string PackageName { get; init; }
        public string Description { get; init; }
    }
}
