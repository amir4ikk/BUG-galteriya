using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Test.Helpers;


namespace Test.InfraStructure;


public class UserRepositoryTest
{
    AppDbContext dbContext;
    IUnitOfWork unitOfWork;

    [SetUp]
    public void Setup()
    {
        dbContext = DbContextHelper.GetDbContext();
        unitOfWork = DbContextHelper.GetUnitOfWork();
    }



    [Test]
    // Test 1
    [TestCase("Abror", 8, 10, "abror4ik@gmail.com", "123", 1)]
    // Test 2
    [TestCase("Saidamirxon", 6, 5, "xumorahacker@gmail.com", "321", 2)]
    public async Task AddAsync(string fullName, int workTime, int perHour, string email, string password, int companyId)
    {
        var user = new User()
        {
            FullName = fullName,
            Work_Time = workTime,
            Per_Hour = perHour,
            Email = email,
            Password = password,
            CompanyId = companyId
        };

        await unitOfWork.User.CreateAsync(user);

        var res = await dbContext.Users.FirstOrDefaultAsync(u => u.FullName == fullName);
        Assert.That(user.FullName, Is.EqualTo(fullName));
    }

    [TearDown]
    public async Task TearDownAsync()
    {
        await dbContext.Database.EnsureDeletedAsync();
        await dbContext.DisposeAsync();
    }



    [Test]
    [TestCase]
    public async Task GetAllAsync()
    {
        var users = await unitOfWork.User.GetAllAsync();

        Assert.That(users.Any(), Is.False);
    }



    [Test]
    // Test 1
    [TestCase(1)]
    // Test 2
    [TestCase(2)]
    public async Task GetByIdAsync(int id)
    {
        var company = await unitOfWork.User.GetByIdAsync(id);

        var res = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        Assert.That(res is null);
    }



    [Test]
    // Test 1
    [TestCase("abror4ik@gmail.com")]
    // Test 2
    [TestCase("saidamirxon@gmail.com")]

    public async Task GetByEmailAsync(string email)
    {
        var companies = await unitOfWork.User.GetByEmailAsync(email);

        var res = dbContext.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        Assert.That(res is not null);
    }



    [Test]
    // Test 1
    [TestCase("Abror", 8, 10, "abror4ik@gmail.com", "123", 1)]
    // Test 2
    [TestCase("Saidamirxon", 6, 5, "saidamirxon@gmail.com", "321", 2)]
    public async Task UpdateAsync(string fullName, int workTime, int perHour, string email, string password, int companyId)
    {
        var user = new User()
        {
            FullName = fullName,
            Work_Time = workTime,
            Per_Hour = perHour,
            Email = email,
            Password = password,
            CompanyId = companyId
        };

        await unitOfWork.User.UpdateAsync(user);

        var res = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
        Assert.That(user.FullName, Is.EqualTo(fullName));
    }



    [Test]
    // Test 1
    [TestCase(1)]
    // Test 2
    [TestCase(2)]
    public async Task DeleteAsync(int id)
    {
        var user = await unitOfWork.User.GetByIdAsync(id);
        await unitOfWork.User.DeleteAsync(user);

        var res = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        Assert.That(res is null);
    }
}
