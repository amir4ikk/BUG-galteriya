using Application.DTOs.BugalterDto;
using Application.DTOs.CompanyDtos;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BUG_galteriya.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BugalterController(IBugalterService bugalterService,
                                IUserService userService) : ControllerBase
{
    private readonly IBugalterService _bugalterService = bugalterService;
    private readonly IUserService _userService = userService;

    [HttpPost]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> CreateAsync([FromForm] AddBugalterDto dto)
    {
        await _bugalterService.CreateAsync(dto);
        return Ok();
    }

    [HttpGet("Bugalters")]
    public async Task<IActionResult> GetAllBugalterAsync()
        => Ok(await _bugalterService.GetAllBugalterAsync());

    [HttpGet("id")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _bugalterService.GetByIdAsync(id));
    }

    [HttpPost("id")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<IActionResult> AddBonusAsync(int id,int balance)
    {
        await _bugalterService.AddBonusAsync(id, balance);
        return Ok();
    }

    [HttpPost("WorkTime")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public async Task<IActionResult> GiveWorkTimeAsync(int id,int WorkTime)
    {
        await _bugalterService.GiveWorkTimeAsync(id, WorkTime);
        return Ok();
    }
}
