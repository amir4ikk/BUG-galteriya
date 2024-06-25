using Domain.Entities;

namespace Application.DTOs.UserDtos;
public class UserDto : AddUserDto
{
    public int Id { get; set; }
    public Company Company { get; set; } = null!;
    public int Salary { get; set; }
    public double Tax { get; set; }
    public int WorkTime { get; set; }

    public static implicit operator UserDto(User user)
    {
        return new UserDto()
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Password = user.Password,
            CompanyId = user.CompanyId,
            Tax = user.Tax,
            Salary = user.Salary,
            WorkTime = user.Work_Time,
        };
    }
}