using Application.DTOs.BugalterDto;
using Application.DTOs.BugalterDtos;
using Domain.Entities;

namespace Application.Interfaces;
public interface IBugalterService
{
    public Task<string> GetBugaltersByIdAsync(int id);
    public Task AddBonusAsync(int id, int balance);
    public Task ToZeroAsync(int id);
    public Task<List<User>> GetAllBugalterAsync();
}
