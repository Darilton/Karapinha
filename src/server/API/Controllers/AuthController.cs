using System.Diagnostics.CodeAnalysis;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model;
using Shared;

namespace API;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService authService;

    public AuthController(IAuthService authService){
        this.authService = authService;
    }

    [HttpPost]
    [AllowAnonymous]
    public ActionResult Login(UserLoginDTO login){      
        return Ok("done");
    }
}
