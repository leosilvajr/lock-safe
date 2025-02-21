using LockSafe.Application.DTOs.LockSafe.Application.DTOs;
using LockSafe.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var result = await _loginService.Login(loginDto);

        if (result == null)
        {
            return Unauthorized(new { Message = "Usuário ou senha inválidos." });
        }

        return Ok(result);
    }

}
