using LockSafe.Application.DTOs;
using LockSafe.Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
[Authorize] // Aplica a autenticação JWT a todos os métodos do controlador
public class PasswordController : ControllerBase
{
    private readonly IPasswordService _passwordService;

    public PasswordController(IPasswordService passwordService)
    {
        _passwordService = passwordService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreatePassword([FromBody] PasswordCreateDTO passwordDto)
    {
        // Obter o ID do usuário logado a partir do token
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        if (userId == 0)
            return Unauthorized(new { Message = "Usuário não autenticado." });

        var createdPassword = await _passwordService.CreatePasswordAsync(passwordDto, userId);

        return CreatedAtAction(nameof(CreatePassword), new { id = createdPassword.Id }, createdPassword);
    }
}
