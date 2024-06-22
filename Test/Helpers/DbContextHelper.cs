using Infastructure.Data;
using Infastructure.Interfaces;
using Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Test.Helpers;


public class DbContextHelper
{
    private static readonly DbContextOptions<AppDbContext> options =
        new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase(databaseName: "LocalDb")
        .Options;

    public static AppDbContext GetDbContext()
        => new AppDbContext(options);

    public static IUnitOfWork GetUnitOfWork()
        => new UnitOfWork(GetDbContext());
}
