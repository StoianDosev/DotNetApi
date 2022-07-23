using MyWeb.Application;
using WebLib.Domain;

namespace Web.Infrastructure;

public class UserRepository : IUserRepository
{
    private static List<User> _fakeUsers = new List<User>(){
        new User(){FirstName = "First", LastName = "Last", Email = "abv@mail.bg", Password="1234"},
        new User(){FirstName = "First1", LastName = "Last1", Email = "1abv@mail.bg", Password="1234"},
        new User(){FirstName = "First2", LastName = "Last2", Email = "2abv@mail.bg", Password="1234"}
    };

    public void Add(User user)
    {
        _fakeUsers.Add(user);
    }

    public User GetUserByEmail(string email)
    {
        return _fakeUsers.FirstOrDefault(x=>x.Email == email);
    }
}