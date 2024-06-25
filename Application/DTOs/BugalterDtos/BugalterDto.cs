using Application.DTOs.BugalterDto;
using Domain.Entities;

namespace Application.DTOs.BugalterDtos;
public class BugalterDto : AddBugalterDto
{
    public int Id { get; set; }

    public static implicit operator BugalterDto(Bugalter bugalter)
    {
        return new BugalterDto()
        {
            Id = bugalter.Id,
            Name = bugalter.Name,
            CompanyId = bugalter.CompanyId,
            Company_Name = bugalter.Company_Name
        };
    }
}
