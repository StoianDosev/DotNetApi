using WebLib.Domain;

namespace MyWeb.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _tokenGenrator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator genrator, IUserRepository userRepository)
    {
        _tokenGenrator = genrator;
        _userRepository = userRepository;
    }

    public AuthResult Register(string firstName,
        string lastName,
        string email,
        string password)
    {
        var user = _userRepository.GetUserByEmail(email);
        if (user is not null)
        {
            throw new Exception("User already exists");
        }

        User createUser = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(createUser);

        
        string token = _tokenGenrator.GenerateToken(createUser.Id, createUser.FirstName, createUser.LastName);
        return new AuthResult(createUser.Id, createUser.FirstName, createUser.LastName, createUser.Email, token);
    }

    public AuthResult Login(string email,
        string password)
    {
        var user =_userRepository.GetUserByEmail(email);
        if(user == null)
        {
            throw new KeyNotFoundException("No email found");
        }
        
        var token = _tokenGenrator.GenerateToken(user.Id, user.FirstName, user.LastName);

        return new AuthResult(user.Id, user.FirstName, user.LastName, email, token);
    }
}   