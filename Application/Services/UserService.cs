using Application.Common.Helper;
using Application.DTOs.UserDtos;
using Application.Interfaces;
using BUGgalteriyaAPI.Application.Interfaces;
using BUGgalteriyaAPI.Application.Common.Exceptions;
using BUGgalteriyaAPI.Application.Common.Utils;
using Domain.Entities;
using Infastructure.Interfaces;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace Application.Services;
public class UserService(IUnitOfWork unitOfWork,
                         IRedisService redisService,
                         IUserRepository userRepository,
                         IHttpContextAccessor accessor) : IUserService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IRedisService _redisService = redisService;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IHttpContextAccessor _accessor = accessor;
    private const string CACHE_KEY = "users";

    public async Task DeleteAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user is null)
            throw new Exception("User not found!");

        await _userRepository.DeleteAsync(user);
        await _redisService.DeleteAsync(CACHE_KEY);
    }

    public async Task<string> GetAllAsync(PaginationParams @params,
                                                        Expression<Func<User, bool>>? expression = null)
    {
        var entities = await _redisService.GetAsync(CACHE_KEY);

        if (entities is not null)
        {
            var data = JsonConvert.DeserializeObject<List<UserDto>>(entities);

            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }

        var users = _userRepository.GetAll(expression!);

        var json = JsonConvert.SerializeObject(users.Select(p => (UserDto)p), Formatting.Indented);

        await _redisService.SetAsync(CACHE_KEY, json);

        return JsonConvert.SerializeObject(users.Select(p => (UserDto)p), Formatting.Indented);
    }

    public async Task<string> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(p => p.Id.Equals(id));

        return user is not null ? JsonConvert.SerializeObject((UserDto)user)
                                : throw new Exception("User not found!");
    }

    public Task UpdateAsync()
    {
        throw new NotImplementedException();
    }

    public async Task GetSalaryAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            throw NotFound();
        user.Salary = user.Work_Time * 4;
        await _userRepository.UpdateAsync(user);
    }

    private StatusCodeExeption NotFound()
    {
        return new StatusCodeExeption(HttpStatusCode.NotFound, "User Not Found");
    }

    public async Task GotMoney(int UserId)
    {
        var user = await _userRepository.GetByIdAsync(UserId);
        if (user is null)
            throw NotFound();
        user.Work_Time = 0;
        await _userRepository.UpdateAsync(user);
    }
}
