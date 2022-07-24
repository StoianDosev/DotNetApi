using System.Runtime.Serialization.Json;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace MWebApplication.Api.Middlewares;

public class CustomErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public CustomErrorHandlingMiddleware(RequestDelegate next)
    {
        this._next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = JsonSerializer.Serialize(new {error = ex.Message});
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        var problem = new ProblemDetails()
        {
            Title ="Error occured",
            Detail = "some error",
            Instance = "Authentication",
            Status = (int)HttpStatusCode.InternalServerError,
            Type = ""
        };

        problem.Extensions.Add("error", ex.Message);

        await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
    }
}