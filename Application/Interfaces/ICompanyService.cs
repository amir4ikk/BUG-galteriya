using Application.DTOs.BugalterDto;
using Application.DTOs.BugalterDtos;
using Domain.Entities;

namespace Application.Interfaces;
public interface ICompanyService
{
    Task<Company?> GetByIdAsync(int id);
    Task<List<Company>> GetAllAsync();
}
