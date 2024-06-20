using Domain.Enums;

namespace Domain.Entities;
public class User : BaseEntity
{
    public string FullName { get; set; } = string.Empty;
    public int Work_Time { get; set; }
    public int Per_Hour { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;


    public int CompanyId { get; set; }
    public int BugalterId { get; set; }
    public bool IsVerified { get; set; } = false;
    public Role Roles { get; set; } = Role.User;
    public string Salt { get; set; } = string.Empty;
}
