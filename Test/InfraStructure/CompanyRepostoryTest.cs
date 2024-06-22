using Domain.Entities;
using Infastructure.Data;
using Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Test.Helpers;


namespace Test.InfraStructure;


public class CompanyRepostoryTest
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
    [TestCase("EPAM", 3000, "")]
    // Test 2
    [TestCase("META", 10000, "")]

    public async Task AddAsync(string Name, int EmployesCount, string CreatorName = "Oybek")
    {
        var company = new Company()
        {
            Name = Name,
            Employees_Count = EmployesCount,
            Creator_Name = CreatorName
        };

        await unitOfWork.Company.CreateAsync(company);

        var res = await dbContext.Companies.FirstOrDefaultAsync(c => c.Name == Name);
        Assert.That(company.Name, Is.EqualTo(res.Name));
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
        var companies = await unitOfWork.Company.GetAllAsync();

        Assert.That(companies.Any(), Is.False);
    }



    [Test]
    // Test 1
    [TestCase(1)]
    // Test 2
    [TestCase(2)]
    public async Task GetByIdAsync(int id)
    {
        var company = await unitOfWork.Company.GetByIdAsync(id);

        var res = await dbContext.Companies.FirstOrDefaultAsync(c => c.Id == id);
        Assert.That(res is null);
    }



    [Test]
    // Test 1
    [TestCase("Google")]
    // Test 2
    [TestCase("Apple")]

    public async Task GetByNameAsync(string name)
    {
        var companies = await unitOfWork.Company.GetByNameAsync(name);

        var res = dbContext.Companies.FirstOrDefaultAsync(c => c.Name.Equals(name));
        Assert.That(res is not null);
    }



    [Test]
    // Test 1
    [TestCase("Google", 1000000, "Sundar Pichai")]
    // Test 2
    [TestCase("Apple", 1050000, "Stiv Jobs")]
    public async Task UpdateAsync(string Name, int EmployeeCount, string CreatorName)
    {
        var company = new Company()
        {
            Name = Name,
            Employees_Count = EmployeeCount,
            Creator_Name = CreatorName
        };

        await unitOfWork.Company.UpdateAsync(company);

        var res = await dbContext.Companies.FirstOrDefaultAsync(c => c.Id == company.Id);
        Assert.That(company.Name, Is.EqualTo(Name));
    }



    [Test]
    // Test 1
    [TestCase(1)]
    // Test 2
    [TestCase(2)]
    public async Task DeleteAsync(int id)
    {
        var company = await unitOfWork.Company.GetByIdAsync(id);
        await unitOfWork.Company.DeleteAsync(company);

        var res = await dbContext.Companies.FirstOrDefaultAsync(c => c.Id == id);
        Assert.That(res is null);
    }
}
