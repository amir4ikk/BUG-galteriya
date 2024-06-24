using Application.DTOs.CompanyDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BUG_galteriya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController(ICompanyService comp,
                                   IAdminService admin) : ControllerBase
    {
        private readonly ICompanyService _comp = comp;
        private readonly IAdminService _admin = admin;

        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> CreateAsync([FromForm] AddCompanyDto dto)
        {
            await _comp.CreateAsync(dto);
            return Ok();
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _comp.GetByIdAsync(id));
        }

        [HttpGet("movies")]
        [Authorize]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _comp.GetAllAsync());
        }
    }
}
