using Application.DTOs.BugalterDto;
using Application.DTOs.BugalterDtos;

namespace Application.Interfaces;
public interface IBugalterService
{
    public Task<UserDtoS> GetByIdAsync(int id);
    public Task AddBonusAsync(int id, int balance);
    public Task ToZeroAsync(int id);
    public Task<List<UserDtoS>> GetAllAsync();
}
