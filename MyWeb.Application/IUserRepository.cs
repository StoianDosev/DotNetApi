using WebLib.Domain;

namespace MyWeb.Application;

public interface IUserRepository
{
    User GetUserByEmail(string email);
    
    void Add(User user);
}