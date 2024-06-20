using Domain.Entities;

namespace Application.DTOs.CompanyDtos;
public class CompanyDto : AddCompanyDto
{
    public int Id { get; set; }

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
}
