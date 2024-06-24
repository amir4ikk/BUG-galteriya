using Application.DTOs.BugalterDto;
using Application.DTOs.BugalterDtos;
using Application.DTOs.CompanyDtos;
using Domain.Entities;

namespace Application.Interfaces;
public interface ICompanyService
{
    Task<CompanyDto?> GetByIdAsync(int id);
    Task<List<CompanyDto>> GetAllAsync();
    Task CreateAsync(AddCompanyDto dto);
}
