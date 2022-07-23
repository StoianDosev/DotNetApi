namespace MyWebApplication.Api.Models
{
    public record AuthenticationResponce(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string token);
}