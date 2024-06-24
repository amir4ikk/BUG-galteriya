using Application.Interfaces;
using Infastructure.Interfaces;
using System.Net;
using BUGgalteriyaAPI.Application.Common.Exceptions;
using Domain.Entities;
using Domain.Enums;
using Application.DTOs.UserDtos;
using Newtonsoft.Json;

namespace Application.Services;

public class BugalterService(IUnitOfWork unitOf,
                             IUserRepository userRepository) : IBugalterService
{
    private readonly IUnitOfWork _unitOf = unitOf;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task AddBonusAsync(int id, int balance)
    {
        var user = await unitOf.User.GetByIdAsync(id);
        if (user is null)
            throw NotFound();
        user.Work_Time += balance / user.Per_Hour;
        await unitOf.User.UpdateAsync(user);
    }

    public async Task<List<User>> GetAllBugalterAsync()
        => (await _unitOf.User.GetAllAsync())
            .Where(p => p.Roles == Role.Admin)
    .ToList();

    public async Task<string> GetBugaltersByIdAsync(int id)
    {
        var bugalter = await _userRepository.GetByIdAsync(p => p.Id.Equals(id));

        return bugalter is not null ? JsonConvert.SerializeObject((UserDto)bugalter)
                                : throw new Exception("Bugalter not found!");
    }

    public async Task ToZeroAsync(int UserId)
    {
        var user = await _userRepository.GetByIdAsync(UserId);
        if (user is null)
            throw NotFound();
        user.Work_Time = 0;
        await _userRepository.UpdateAsync(user);
    }

    private StatusCodeExeption NotFound()
    {
        return new StatusCodeExeption(HttpStatusCode.NotFound, "User Not Found");
    }
}