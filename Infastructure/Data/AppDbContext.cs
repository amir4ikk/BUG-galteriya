using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Data;
public class AppDbContext(DbContextOptions<AppDbContext> dbContext) : DbContext(dbContext)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Bugalter> Bugalters { get; set; }
    public DbSet<Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FullName = "Saidamirxon Abrorbekov",
                Email = "xumorahacker@gmail.com",
                Password = "8a31bb92b2be0203c5ee64e322a9db1406cb02c45170c35ab5c833ec6908a473",
                Roles = Role.SuperAdmin,
                Salt = "ef601c93-c27a-4e46-8518-172da1e102f4",
                IsVerified = true,
            });
    }
}
