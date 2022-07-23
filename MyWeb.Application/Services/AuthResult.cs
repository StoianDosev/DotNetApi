namespace MyWeb.Application.Services;

    public record AuthResult(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string token);
