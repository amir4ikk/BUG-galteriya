using Domain.Entities;

namespace Infastructure.Interfaces;
public interface IBugalterRepository : IGenericRepository<Bugalter>
{
    Task<Bugalter?> GetByNameAsync(string name);
}
