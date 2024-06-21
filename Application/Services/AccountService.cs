using Application.Common.Exceptions;
using Application.Common.Security;
using Application.Common.Validators;
using Application.DTOs.UserDtos;
using Application.Interfaces;
using BUGgalteriyaAPI.Application.Common.Exceptions;
using BUGgalteriyaAPI.Application.Interfaces;
using Domain.Entities;
using FluentValidation;
using Infastructure.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Application.Services;

public class AccountService(IUnitOfWork ofWork,
                            IAuthManager authManager,
                            IValidator<User> validator,
                            IMemoryCache cache,
                            IEmailService emailService,
                            IUserRepository userRepository)
    : IAccountService
{

    public IAuthManager _auth = authManager;

    private readonly IUnitOfWork _ofWork = ofWork;
    private readonly IValidator<User> _validator = validator;
    private readonly IMemoryCache _cache = cache;
    private readonly IEmailService _emailService = emailService;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<string> LoginAsync(LoginDto dto)
    {
        var user = await _userRepository.GiveByEmailAsync(p => p.Email.Equals(dto.Email));
        if (user is null)
            throw new Exception("404 : not found!");

        if (!PasswordHasher.IsEqual(user.Password, dto.Password, user.Password))
            return "Incorrect password!";

        return "JWT";
    }

    public async Task RegisterAsync(AddUserDto dto)
    {
        var user = await _userRepository.GiveByEmailAsync(p => p.Email.Equals(dto.Email));
        if (user is not null)
            throw new Exception("409: user already exists!");
        var comp = await _ofWork.Company.GetByIdAsync(dto.CompanyId);
        if (comp is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Company not found");
        comp.Employees_Count += 1;
        await _ofWork.Company.UpdateAsync(comp);
        var result = PasswordHasher.GetHash(dto.Password, out var salt);
        var entity = (User)dto;
        entity.Password = result;
        entity.Salt = salt;
        await _userRepository.CreateAsync(entity);


    }

    public async Task SendCodeAsync(string email)
    {
        var user = await _ofWork.User.GetByEmailAsync(email);
        if (user is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found!");
        var code = GeneratedCode();
        _cache.Set(email, code, TimeSpan.FromSeconds(60));
        await _emailService.SendMessageAsync(email, "Verification code!", code);
    }

    public async Task<bool> CheckCodeAsync(string email, string code)
    {
        var user = await _ofWork.User.GetByEmailAsync(email);
        if (user is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "User not found!");
        if (_cache.TryGetValue(email, out var result))
        {
            if (code.Equals(result))
            {
                user.IsVerified = true;
                await _ofWork.User.UpdateAsync(user);
                return true;
            }
            else
                throw new StatusCodeExeption(HttpStatusCode.Conflict, "Code is incorrect!");
        }
        else
            throw new StatusCodeExeption(HttpStatusCode.BadRequest, "Code expired!");
    }
    private string GeneratedCode()
        => (new Random().Next(10000, 99999)).ToString();

}
