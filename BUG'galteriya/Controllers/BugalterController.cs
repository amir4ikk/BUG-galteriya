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
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllAsync()
        => Ok(await _bugalterService.GetAllAsync());

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetByIdAsync(int id)
        => Ok(await _bugalterService.GetByIdAsync(id));
}
