using Domain.Entities;
using Domain.Enums;

namespace Application.DTOs.UserDtos;
public class AddUserDto
{
    public string FullName { get; set; } = string.Empty;
    public int Work_Time { get; set; }
    public int Per_Hour { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int CompanyId { get; set; }

    public static implicit operator User(AddUserDto dto)
    {
        return new User
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Password = dto.Password,
            CompanyId = dto.CompanyId,
        };
    }
}
