using Application.DTOs.BugalterDto;
using Application.DTOs.BugalterDtos;

namespace Application.Interfaces;
public interface IBugalterService
{
    Task<BugalterDto?> GetByIdAsync(int id);
    Task AddBonusAsync(int id, int balance);
    Task<List<BugalterDto>> GetAllBugalterAsync();
    Task CreateAsync(AddBugalterDto dto);
    Task GiveWorkTimeAsync(int id, int WorkTime);
}
