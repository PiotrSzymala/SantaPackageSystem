using Microsoft.EntityFrameworkCore;
using SantaPackageSystem.Application.Models;
using SantaPackageSystem.Application.Models.DTO;
using SantaPackageSystem.Infrastructure.Repository;

namespace SantaPackageSystem.Application.Services
{
    public class ElfService : IElfService
    {
        private readonly ApplicationDbContext _context;

        public ElfService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetElfDTO> GetElfById(long id)
        {
            var elf = await _context.Elves.FirstOrDefaultAsync(x => x.Id == id);

            return new GetElfDTO()
            {
                Id = elf.Id,
                Name = elf.Name,
                IsOnLeave = elf.IsOnLeave,
                IsOnParentalLeave = elf.IsOnParentalLeave,
            };
        }


        public async Task<bool> GrantParentalLeave(long elfId)
        {
            var elf = await _context.Elves.FirstOrDefaultAsync(x => x.Id == elfId);

            if (elf.IsOnParentalLeave)
                return false;

            elf.IsOnParentalLeave = true;

            _context.Elves.Update(elf);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RevokeParentalLeave(long elfId)
        {
            var elf = await _context.Elves.FirstOrDefaultAsync(x => x.Id == elfId);

            if (!elf.IsOnParentalLeave)
                return false;

            elf.IsOnParentalLeave = false;

            _context.Elves.Update(elf);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> GrantLeave(long elfId)
        {
            var elf = await _context.Elves.FirstOrDefaultAsync(x => x.Id == elfId);

            if (elf.IsOnLeave)
                return false;

            elf.IsOnLeave = true;

            _context.Elves.Update(elf);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RevokeLeave(long elfId)
        {
            var elf = await _context.Elves.FirstOrDefaultAsync(x => x.Id == elfId);

            if (!elf.IsOnLeave)
                return false;

            elf.IsOnLeave = false;

            _context.Elves.Update(elf);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Elf> HireNewElf(CreateElfDto newElfData)
        {
            var newElf = new Elf
            {
                Name = newElfData.Name,
                IsOnLeave = false,
                IsOnParentalLeave = false
            };

            await _context.Elves.AddAsync(newElf);
            await _context.SaveChangesAsync();

            return newElf;
        }
    }
}
