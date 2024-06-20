using Domain.Entities;

namespace Infastructure.Interfaces;
public interface ICompanyRepository : IGenericRepository<Company>
{
    Task<List<Company>> GetByNameAsync(string name);
}
