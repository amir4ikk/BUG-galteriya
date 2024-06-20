using Domain.Entities;

namespace BUGgalteriyaAPI.Application.Interfaces;

public interface IAuthManager
{
    string GeneratedToken(User user);
}
