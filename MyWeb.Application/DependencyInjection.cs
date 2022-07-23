using Microsoft.Extensions.DependencyInjection;
using MyWeb.Application.Services;

namespace MyWeb.Application;
public static class DependecyInjection
{
    public static IServiceCollection AddMyWebApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}