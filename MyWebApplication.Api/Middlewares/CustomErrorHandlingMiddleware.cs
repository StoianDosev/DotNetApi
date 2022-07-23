using System.Runtime.Serialization.Json;
using System.Net;
using System.Text.Json;

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
        await context.Response.WriteAsync(result);
    }
}