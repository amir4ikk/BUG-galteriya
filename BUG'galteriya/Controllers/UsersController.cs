using Application.DTOs.UserDtos;
using Application.Interfaces;
using Application.Services;
using BUGgalteriyaAPI.Application.Common.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ResumeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet("{id}")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public async Task<IActionResult> GetByIdAsync(int id)
    => Ok(await _userService.GetByIdAsync(id));

    [HttpDelete("id")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _userService.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
    => Ok(await _userService.GetAllAsync(@params, p => p.IsVerified != true));

    [HttpGet("{UserId}")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public async Task<IActionResult> GotMoney(int UserId)
    {
        await _userService.GotMoney(UserId);
        return Ok();
    }

    [HttpGet("{Userid}")]
    [Authorize]

    public async Task<IActionResult> GetSalaryAsync(int Userid)
    {
        await _userService.GetSalaryAsync(Userid);
        return Ok();
    }
}
