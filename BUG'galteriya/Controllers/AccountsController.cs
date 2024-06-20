using Application.DTOs.UserDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ResumeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController(IAccountService accountService) : ControllerBase
{
    private readonly IAccountService _accountService = accountService;

    [HttpPost("registr")]
    [AllowAnonymous]
    public async Task<IActionResult> RegistrAsync([FromForm] AddUserDto dto)
    {
        await _accountService.RegisterAsync(dto);
        return Ok();
    }

    [HttpPost("login"), AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromForm] LoginDto dto)
    {
        var result = await _accountService.LoginAsync(dto);
        return Ok($"Token : {result}");
    }
    [HttpPost("sendcode")]
    public async Task<IActionResult> SendCodeAsync([FromForm]string email)
    {
        await _accountService.SendCodeAsync(email);
        return Ok();
    }
    [HttpPost("check")]
    public async Task<IActionResult> CheckCodeAsync([FromForm]string email, [FromForm]string code)
        => Ok(await _accountService.CheckCodeAsync(email, code));
}
