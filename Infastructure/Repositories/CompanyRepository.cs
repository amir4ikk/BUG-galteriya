using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Repositories;
public class CompanyRepository(AppDbContext dbContext) : GenericRepository<Company>(dbContext), ICompanyRepository
{
    public async Task<List<Company>> GetByNameAsync(string name)
    {
        var companies = await _dbContext.Companies.ToListAsync();

        return companies.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
    }
}
