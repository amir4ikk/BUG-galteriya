using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BUG_galteriya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompantController(ICompanyService comp) : ControllerBase
    {
        private readonly ICompanyService comp = comp;
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await comp.GetAllAsync());
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetAllAsync(int id)
        {
            return Ok(await comp.GetByIdAsync(id));
        }
    }
}
