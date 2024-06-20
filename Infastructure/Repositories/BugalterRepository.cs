using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Repositories;
public class BugalterRepository(AppDbContext dbContext) : GenericRepository<Bugalter>(dbContext), IBugalterRepository
{
    public async Task<Bugalter?> GetByNameAsync(string name)
    {
        return await _dbContext.Bugalters.FirstOrDefaultAsync(x => x.Name == name);
    }
}
