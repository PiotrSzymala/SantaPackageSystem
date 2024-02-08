using Microsoft.AspNetCore.Mvc;
using SantaPackageSystem.Application.Models.DTO;
using SantaPackageSystem.Application.Services;

namespace SantaPackageSystem.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackagesController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [Route("/package/get/{id}")]
        [HttpGet]
        public async Task<ActionResult> GetPackageById([FromRoute] long id)
        {
            var result = await _packageService.GetPackage(id);
            return Ok(result);
        }

        [Route("/package/create")]
        [HttpPost]
        public async Task<ActionResult> CreatePackage([FromBody] CreatePackageDTO newPackageData)
        {
            var result = await _packageService.CreatePackage(newPackageData);

            return Ok(result);
        }

        [Route("/package/assign")]
        [HttpPatch]
        public async Task<ActionResult> AssignPackageToElf([FromBody] AssignPackageDTO assignmentData)
        {
            var result = await _packageService.AssignPackageToElf(assignmentData.PackageId, assignmentData.ElfId);

            if (!result)
                return BadRequest(new { message = "Failed to assign the package." });

            return Ok(new { message = "Package assigned successfully." });
        }
    }
}
