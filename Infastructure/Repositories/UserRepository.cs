using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infastructure.Repositories;
public class UserRepository(AppDbContext dbContext) : GenericRepository<User>(dbContext), IUserRepository
{
    public async Task<User?> GiveByEmailAsync(Expression<Func<User, bool>> expression)
        => await _dbContext.Users.FirstOrDefaultAsync(expression);
    public async Task<User?> GetByEmailAsync(string email)
        => await _dbContext.Users.FirstOrDefaultAsync(mail => mail.Email == email);
    public IQueryable<User> GetAll(Expression<Func<User, bool>> expression)
       => _dbContext.Users.Where(expression);
    public async Task<User?> GetByIdAsync(Expression<Func<User, bool>> expression)
        => await _dbContext.Users.FirstOrDefaultAsync(expression);
}
