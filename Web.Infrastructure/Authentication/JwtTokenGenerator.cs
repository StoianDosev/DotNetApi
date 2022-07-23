using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyWeb.Application;

namespace Web.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _settings;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> settings)
    {
        _dateTimeProvider = dateTimeProvider;
        _settings = settings.Value;
    }

    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, userId.ToString()),
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Secret)),
            SecurityAlgorithms.HmacSha256
        );

        var securityToken = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_settings.ExpiresInMinutes),
            claims: claims,
        signingCredentials: signingCredentials);

        string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

        return token;
    }
}