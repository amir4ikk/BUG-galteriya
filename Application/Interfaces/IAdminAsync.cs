using Domain.Entities;

namespace Application.Interfaces;

public interface IAdminService
{
    Task ChangeUserRoleAsync(int id);
    Task DeleteUserAsync(int id);
    Task<List<User>> GetAllAdminAsync();
    Task CreateCompanyAsync(string Company, string Creator);
    Task DeleteCompanyAsync(int id);
    Task<List<Company>> GetAllCompanies();
}
