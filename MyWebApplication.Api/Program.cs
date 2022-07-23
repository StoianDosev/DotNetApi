using MyWebApplication.Api;
using MyWeb.Application;
using Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddMyWebApplication();
    builder.Services.AddWebInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
};



var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

