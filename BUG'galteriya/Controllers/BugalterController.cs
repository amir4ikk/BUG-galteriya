using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BUG_galteriya.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BugalterController(IBugalterService bugalterService) : ControllerBase
{
    private readonly IBugalterService _bugalterService = bugalterService;

    [HttpGet("users")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> GetAllBugalterAsync()
        => Ok(await _bugalterService.GetAllBugalterAsync());

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> GetBugaltersByIdAsync(int id)
        => Ok(await _bugalterService.GetBugaltersByIdAsync(id));

    [HttpPost("id")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> AddBonusAsync(int id,int balance)
    {
        await _bugalterService.AddBonusAsync(id, balance);
        return Ok();
    }
    [HttpGet("{UserId}")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> ToZeroAsync(int UserId)
    {
        await _bugalterService.ToZeroAsync(UserId);
        return Ok();
    }
}
