using Domain.Entities;
using Domain.Enums;

namespace Application.DTOs.UserDtos;

public class UpdateUserDto
{
    public string FullName { get; set; } = "";
    public string Email { get; set; } = "";
    public int CompanyId { get; set; }
    public string Password { get; set; } = "";

    public static implicit operator User(UpdateUserDto dto)
    {
        return new User()
        {
            FullName = dto.FullName,
            Email = dto.Email,
            CompanyId = dto.CompanyId,
            Password = dto.Password
        };
    }
}
