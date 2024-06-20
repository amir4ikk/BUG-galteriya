using Infastructure.Data;
using Infastructure.Interfaces;

namespace Infastructure.Repositories;
public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public ICompanyRepository Company => new CompanyRepository(_appDbContext);

    public IBugalterRepository Bugalter => new BugalterRepository(_appDbContext);

    public IUserRepository User => new UserRepository(_appDbContext);
}
