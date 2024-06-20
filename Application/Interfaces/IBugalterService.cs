using Application.DTOs.BugalterDto;
using Application.DTOs.BugalterDtos;

namespace Application.Interfaces;
public interface IBugalterService
{
    Task CreateAsync(AddBugalterDto dto);
    Task<BugalterDto?> GetByIdAsync(int id);
    Task<List<BugalterDto>> GetAllAsync();
    Task DeleteAsync(int id);
    Task UpdateAsync(BugalterDto dto);
}
