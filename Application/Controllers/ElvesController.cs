using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SantaPackageSystem.Application.Models.DTO;
using SantaPackageSystem.Application.Services;

namespace SantaPackageSystem.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElvesController : ControllerBase
    {
        private readonly IElfService _elfService;

        public ElvesController(IElfService elfService)
        {
            _elfService = elfService;
        }

        [Route("/elf/get/{id}")]
        [HttpGet]
        public async Task<ActionResult> GetElfById([FromRoute] long id)
        {
            var result = await _elfService.GetElfById(id);

            return Ok(result);
        }

        [Route("/elf/create")]
        [HttpPost]
        public async Task<ActionResult> HireNewElf([FromBody] CreateElfDto newElfData)
        {
            var result = await _elfService.HireNewElf(newElfData);

            return Ok(result);
        }

        [HttpPatch("grantParentalLeave/{elfId}")]
        public async Task<IActionResult> GrantParentalLeave(long elfId)
        {
            var result = await _elfService.GrantParentalLeave(elfId);

            if (result)
                return Ok(new { message = "Parental leave granted successfully." });

            return BadRequest(new { message = "Failed to grant parental leave or elf is already on parental leave." });
        }

        [HttpPatch("revokeParentalLeave/{elfId}")]
        public async Task<IActionResult> RevokeParentalLeave(long elfId)
        {
            var result = await _elfService.RevokeParentalLeave(elfId);

            if (result)
                return Ok(new { message = "Parental leave revoked successfully." });

            return BadRequest(new { message = "Failed to revoke parental leave or elf is not currently on parental leave." });
        }

        [HttpPatch("grantLeave/{elfId}")]
        public async Task<IActionResult> GrantLeave(long elfId)
        {
            var result = await _elfService.GrantLeave(elfId);
            if (result)
                return Ok(new { message = "Leave granted successfully." });

            return BadRequest(new { message = "Failed to grant leave or elf is already on leave." });
        }

        [HttpPatch("revokeLeave/{elfId}")]
        public async Task<IActionResult> RevokeLeave(long elfId)
        {
            var result = await _elfService.RevokeLeave(elfId);

            if (result)
                return Ok(new { message = "Leave revoked successfully." });

            return BadRequest(new { message = "Failed to revoke leave or elf is not currently on leave." });
        }
    }
}
