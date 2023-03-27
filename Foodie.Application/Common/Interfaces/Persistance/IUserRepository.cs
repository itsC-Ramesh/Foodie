using Foodie.Domain.Entities;

namespace Foodie.Application.Common.Interfaces.Persistance;
public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);

}
