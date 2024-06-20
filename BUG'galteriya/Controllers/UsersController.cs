using Application.DTOs.UserDtos;
using Application.Interfaces;
using BUGgalteriyaAPI.Application.Common.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ResumeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet("{id}")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        => Ok(await _userService.GetByIdAsync(id));

        [HttpPut]

        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateUserDto dto)
        {
            var id = int.Parse(HttpContext.User.FindFirst("Id")!.Value);

            await _userService.UpdateAsync(id, dto);
            return Ok();
        }

        [HttpDelete("id")]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _userService.GetAllAsync(@params, p => p.IsVerified != true));
    }
}
