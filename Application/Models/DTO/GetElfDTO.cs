namespace SantaPackageSystem.Application.Models.DTO
{
    public record GetElfDTO
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public bool IsOnLeave { get; init; }
        public bool IsOnParentalLeave { get; init; }
    }
}
