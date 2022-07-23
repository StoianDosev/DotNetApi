using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Api.Models;
using MyWeb.Application.Services;

namespace MyWebApplication.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authService;

    public AuthenticationController(IAuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    public IActionResult Register(RegisterRequest request)
    {
        return Ok(_authService.Register(request.FirstName,request.LastName,request.Email,request.Password));
    }

    [HttpPost("Login")]
    public IActionResult Login(LoginRequest request)
    {
        return Ok(_authService.Login(request.Email,request.Password));
    }
}