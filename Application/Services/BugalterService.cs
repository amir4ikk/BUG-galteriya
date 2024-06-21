using Application.Interfaces;
using Infastructure.Interfaces;
using System.Net;
using BUGgalteriyaAPI.Application.Common.Exceptions;
using Application.DTOs.BugalterDtos;

namespace Application.Services;

public class BugalterService(IUnitOfWork unitOf) : IBugalterService
{
    private readonly IUnitOfWork unitOf = unitOf;

    public async Task AddBonusAsync(int id, int balance)
    {
        var user = await unitOf.User.GetByIdAsync(id);
        if (user is null)
            throw NotFound();
        user.Work_Time += balance / user.Per_Hour;
        await unitOf.User.UpdateAsync(user);
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var all = await unitOf.User.GetAllAsync();
        return all.Select(X => (UserDto)X).ToList();
    }

    public async Task<UserDto> GetByIdAsync(int id)
    {
        var user = await unitOf.User.GetByIdAsync(id);
        if (user is null)
            throw NotFound();
        return (UserDto)user;
    }

    public async Task ToZeroAsync(int id)
    {
        var user = await unitOf.User.GetByIdAsync(id);
        if (user is null)
            throw NotFound();
        user.Work_Time = 0;
        await unitOf.User.UpdateAsync(user);
    }

    private StatusCodeExeption NotFound()
    {
        return new StatusCodeExeption(HttpStatusCode.NotFound, "User Not Found");
    }
}
