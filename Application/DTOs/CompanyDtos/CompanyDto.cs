using Domain.Entities;

namespace Application.DTOs.CompanyDtos;
public class CompanyDto : AddCompanyDto
{
    public int Id { get; set; }
    int Employees_Count { get; set; }


    public static implicit operator CompanyDto(Company company)
    {
        return new CompanyDto()
        {
            Id = company.Id,
            Name = company.Name,
            Creator_Name = company.Creator_Name,
            Employees_Count = company.Employees_Count,
        };
    }

    public static implicit operator Company(CompanyDto dto)
    {
        return new Company()
        {
            Id = dto.Id,
            Name = dto.Name,
            Creator_Name = dto.Creator_Name,
            Employees_Count = dto.Employees_Count,
        };
    }
}
