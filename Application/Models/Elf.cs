namespace SantaPackageSystem.Application.Models
{
    public class Elf
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOnLeave { get; set; }
        public bool IsOnParentalLeave { get; set; }
        public List<Package> Packages { get; set; } = new List<Package>();
    }
}
