using Domain.Entities;

namespace Application.DTOs.BugalterDto;
public class AddBugalterDto
{
    public string Name { get; set; } = string.Empty;
    public string Company_Name { get; set; } = string.Empty;

    public int CompanyId { get; set; }

    public static implicit operator Bugalter(AddBugalterDto dto)
    {
        return new Bugalter
        {
            Name = dto.Name,
            Company_Name = dto.Company_Name,
            CompanyId = dto.CompanyId
        };
    }
}
