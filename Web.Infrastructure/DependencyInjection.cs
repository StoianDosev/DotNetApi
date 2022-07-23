using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWeb.Application;
using Web.Infrastructure.Authentication;
using Web.Infrastructure.Services;

namespace Web.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddWebInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IUserRepository,UserRepository>();
        return services;
    }
}