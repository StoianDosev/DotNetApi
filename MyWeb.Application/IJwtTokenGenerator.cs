namespace MyWeb.Application;
public interface IJwtTokenGenerator
{
    public string GenerateToken(Guid userId, string firstName, string lastName);
}
