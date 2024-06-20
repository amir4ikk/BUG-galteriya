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
                Password = "186cf774c97b60a1c106ef718d10970a6a06e06bef89553d9ae65d938a886eae",
                Roles = Role.SuperAdmin,
            });
    }
}
