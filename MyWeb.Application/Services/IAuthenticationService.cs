namespace MyWeb.Application.Services;

public interface IAuthenticationService
{
    public AuthResult Register(string firstName,
        string lastName,
        string email,
        string password);
    
    public AuthResult Login(string email,
        string password);
}