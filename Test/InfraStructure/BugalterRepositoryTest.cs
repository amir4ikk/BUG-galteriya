using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Test.Helpers;


namespace Test.InfraStructure;


public class BugalterRepositoryTest
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
    [TestCase("Abror", "EPAM", 1)]
    // Test 2
    [TestCase("Saidamirxon", "UZUM", 2)]
    public async Task AddAsync(string name, string companyName, int companyId)
    {
        var bugalter = new Bugalter()
        {
            Name = name,
            Company_Name = companyName,
            CompanyId = companyId
        };

        await unitOfWork.Bugalter.CreateAsync(bugalter);
        
        var res = await dbContext.Bugalters.FirstOrDefaultAsync(b => b.Name == name);
        Assert.That(bugalter.Name, Is.EqualTo(res.Name));
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
        var bugalters = await unitOfWork.Bugalter.GetAllAsync();

        Assert.That(bugalters.Any(), Is.False);
    }



    [Test]
    // Test 1
    [TestCase(1)]
    // Test 2
    [TestCase(2)]
    public async Task GetByIdAsync(int id)
    {
        var company = await unitOfWork.Bugalter.GetByIdAsync(id);

        var res = await dbContext.Bugalters.FirstOrDefaultAsync(b => b.Id == id);
        Assert.That(res is null);
    }



    [Test]
    // Test 1
    [TestCase("Abror")]
    // Test 2
    [TestCase("Saidamirxon")]

    public async Task GetByNameAsync(string name)
    {
        var companies = await unitOfWork.Company.GetByNameAsync(name);

        var res = dbContext.Companies.FirstOrDefaultAsync(c => c.Name.Equals(name));
        Assert.That(res is not null);
    }



    [Test]
    // Test 1
    [TestCase("Saidamirxon", "Microsoft", 1)]
    // Test 2
    [TestCase("Abror", "Apple", 2)]
    public async Task UpdateAsync(string Name, string companyName, int companyId)
    {
        var bugalter = new Bugalter()
        {
            Name = Name,
            Company_Name = companyName,
            CompanyId = companyId
        };

        await unitOfWork.Bugalter.UpdateAsync(bugalter);

        var res = await dbContext.Bugalters.FirstOrDefaultAsync(b => b.Id == bugalter.Id);
        Assert.That(bugalter.Name, Is.EqualTo(Name));
    }



    [Test]
    // Test 1
    [TestCase(1)]
    // Test 2
    [TestCase(2)]
    public async Task DeleteAsync(int id)
    {
        var bugalter = await unitOfWork.Bugalter.GetByIdAsync(id);
        await unitOfWork.Bugalter.DeleteAsync(bugalter);

        var res = await dbContext.Bugalters.FirstOrDefaultAsync(b => b.Id == id);
        Assert.That(res is null);
    }
}
