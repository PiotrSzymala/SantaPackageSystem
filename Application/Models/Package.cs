namespace SantaPackageSystem.Application.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string PackageName { get; set; }
        public string Description { get; set; }
        public int? AssignedElfId { get; set; }
        public Elf? AssignedElf { get; set; }
    }
}
