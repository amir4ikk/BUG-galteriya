namespace Infastructure.Interfaces;
public interface IUnitOfWork
{
    ICompanyRepository Company { get; }
    IBugalterRepository Bugalter { get; }
    IUserRepository User { get; }
}
