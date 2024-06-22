using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using FluentValidation;
using Infastructure.Interfaces;
using Moq;


namespace Test.Services;


public class BugalterServiceTest
{
    private Mock<IUnitOfWork> _mockUnitOfWork = new Mock<IUnitOfWork>();
    private Mock<IValidator<Bugalter>> _mockValidator = new Mock<IValidator<Bugalter>>();
    private IUnitOfWork _unitOfWork;
    private IValidator<Bugalter> _validator;
    private IBugalterService _bugalterService;


    [SetUp]
    public void Setup()
    {
        _unitOfWork = _mockUnitOfWork.Object;
        _validator = _mockValidator.Object;
        _bugalterService = new BugalterService(_unitOfWork);
    }



    [Test]
    [TestCase()]
    public async Task GetAllAsync()
    {
        var users = await _unitOfWork.User.GetAllAsync();

        Assert.That(users.Any(), Is.False);
    }



    [Test]
    // Test 1
    [TestCase(1)]
    // Test 2
    [TestCase(2)]
    public async Task GetByIdAsync(int userId)
    {
        // All Ready Exists any User
        var user = await _unitOfWork.User.GetByIdAsync(userId);

        Assert.That(user, Is.Not.Null);
    }



    [Test]
    // Test 1
    [TestCase(1)]
    // Test 2
    [TestCase(2)]
    public async Task ToZeroAsync(int userId)
    {
        var user = await _unitOfWork.User.GetByIdAsync(userId);
        user.Work_Time = 0;
        await _unitOfWork.User.UpdateAsync(user);

        var res = await _unitOfWork.User.GetByIdAsync(userId);

        Assert.That(res.Work_Time == 0, Is.True);
    }



    [Test]
    // Test 1
    [TestCase(1, 100)]
    // Test 2
    [TestCase(2, 1000)]
    public async Task AddBonusAsync(int userId, int balance)
    {
        var oldUser = await _unitOfWork.User.GetByIdAsync(userId);
        await _bugalterService.AddBonusAsync(userId, balance);
        var newUser = await _unitOfWork.User.GetByIdAsync(userId);

        Assert.That(oldUser.Work_Time, Is.Not.EqualTo(newUser.Work_Time));
    }
}
