using LockSafe.Application.DTOs;
using LockSafe.Application.DTOs.LockSafe.Application.DTOs;

namespace LockSafe.Application.Services.Interface
{
    public interface ILoginService
    {
        Task<LoginResponseDto> Login(LoginDto loginDto);
    }
}
