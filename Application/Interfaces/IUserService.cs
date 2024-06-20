using Application.DTOs.UserDtos;
using BUGgalteriyaAPI.Application.Common.Utils;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Interfaces;
public interface IUserService
{
    Task<string> GetAllAsync(PaginationParams @params,
                                    Expression<Func<User, bool>>? expression = null);
    Task<string> GetByIdAsync(Guid id);
    Task UpdateAsync(int id, UpdateUserDto dto);
    Task DeleteAsync(Guid id);
}
