using Domain.Entities;
using System.Linq.Expressions;

namespace Infastructure.Interfaces;
public interface IUserRepository : IGenericRepository<User>
{
    IQueryable<User> GetAll(Expression<Func<User, bool>> expression);
    Task<User?> GiveByEmailAsync(Expression<Func<User, bool>> expression);
    Task<User?> GetByIdAsync(Expression<Func<User, bool>> expression);
    Task<User?> GetByEmailAsync(string email);
}
