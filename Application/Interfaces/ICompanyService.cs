using Application.DTOs.BugalterDto;
using Application.DTOs.BugalterDtos;

namespace Application.Interfaces;
public interface ICompanyService
{
    Task CreateAsync(AddBugalterDto dto);
    Task<BugalterDto?> GetByIdAsync(int id);
    Task<List<BugalterDto>> GetAllAsync();
    Task DeleteAsync(int id);
    Task UpdateAsync(BugalterDto dto);
}
