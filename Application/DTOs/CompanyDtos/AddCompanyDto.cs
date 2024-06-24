using Domain.Entities;

namespace Application.DTOs.CompanyDtos;
public class AddCompanyDto
{
    public string Name { get; set; } = string.Empty;
    public string Creator_Name { get; set; } = string.Empty;

    public static implicit operator Company(AddCompanyDto company)
    {
        return new Company
        {
            Name = company.Name,
            Creator_Name = company.Creator_Name,
        };
    }
}
