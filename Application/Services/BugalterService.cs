using Application.Interfaces;
using Infastructure.Interfaces;
using System.Net;
using BUGgalteriyaAPI.Application.Common.Exceptions;
using Domain.Entities;
using Domain.Enums;
using Application.DTOs.UserDtos;
using Newtonsoft.Json;
using Application.DTOs.CompanyDtos;
using Application.DTOs.BugalterDto;
using FluentValidation;
using Application.Common.Validators;
using Application.DTOs.BugalterDtos;

namespace Application.Services;

public class BugalterService(IUnitOfWork unitOf,
                             IUserRepository userRepository,
                             IValidator<Bugalter> validator) : IBugalterService
{
    private readonly IUnitOfWork _unitOf = unitOf;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IValidator<Bugalter> _validator = validator;

    public async Task CreateAsync(AddBugalterDto dto)
    {
        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidationException(result.GetErrorMessages());
        await _unitOf.Bugalter.CreateAsync((Bugalter)dto);
    }

    public async Task GiveWorkTimeAsync(int id, int WorkTime)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            throw NotFound();
        user.Work_Time = WorkTime;
        await _userRepository.UpdateAsync(user);
    }

    public async Task AddBonusAsync(int id, int balance)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user is null)
            throw NotFound();
        user.Work_Time += balance / user.Per_Hour;
        await _userRepository.UpdateAsync(user);
    }
    private StatusCodeExeption NotFound()
    {
        return new StatusCodeExeption(HttpStatusCode.NotFound, "User Not Found");
    }

    public async Task<BugalterDto?> GetByIdAsync(int id)
    {
        var bugalter = await _unitOf.Bugalter.GetByIdAsync(id);
        if (bugalter is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Bugalter topilmadi");

        return bugalter;
    }

    public async Task<List<BugalterDto>> GetAllBugalterAsync()
    {
        var bugalter = await _unitOf.Bugalter.GetAllAsync();

        return bugalter.Select(item => (BugalterDto)item).ToList();
    }
}