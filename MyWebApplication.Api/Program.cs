using MyWebApplication.Api;
using MyWeb.Application;
using Web.Infrastructure;
using MWebApplication.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddMyWebApplication();
    builder.Services.AddWebInfrastructure(builder.Configuration);
    builder.Services.AddMyWebApi();
};



var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseMiddleware<CustomErrorHandlingMiddleware>();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

