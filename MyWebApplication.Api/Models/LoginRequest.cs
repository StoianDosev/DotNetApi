namespace MyWebApplication.Api.Models

{
    public record LoginRequest(
        string Email,
        string Password);
}