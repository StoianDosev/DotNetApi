namespace MyWebApplication.Api;

using Microsoft.Extensions.DependencyInjection;

public static class DependecyInjection
{
    public static IServiceCollection AddMyWebApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}