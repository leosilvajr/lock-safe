using LockSafe.Application.DTOs;
using LockSafe.Application.DTOs.LockSafe.Application.DTOs;
using LockSafe.Application.Services.Interface;
using LockSafe.Domain.Models;
using LockSafe.Infra.Repositories.Interface;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class LoginService : ILoginService
{
    private readonly IUserRepository _userRepository;
    private readonly JwtSettings _jwtSettings;

    public LoginService(IUserRepository userRepository, IOptions<JwtSettings> jwtSettings)
    {
        _userRepository = userRepository;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<LoginResponseDto> Login(LoginDto loginDto)
    {
        var user = await _userRepository.GetByUserNameAsync(loginDto.UserName);

        if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            return null;

        var tokenString = GerarJwtToken(user);

        // Retornar as informações do login
        return new LoginResponseDto
        {
            UserName = user.UserName,
            Email = user.Email,
            Token = tokenString
        };
    }

    private string GerarJwtToken(Users user)
    {
        // Criar os claims para o JWT
        var claims = new[]
        {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // Adiciona o ID do usuário
        new Claim(ClaimTypes.Name, user.UserName),               // Adiciona o nome do usuário
        new Claim(ClaimTypes.Email, user.Email),                 // Adiciona o email do usuário
        new Claim(ClaimTypes.Role, "User")                       // Adiciona a role (exemplo)
    };

        // Gerar o JWT
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }


}
