using LockSafe.Application.DTOs;

namespace LockSafe.Application.Services.Interface
{
    public interface IPasswordService
    {
        Task<PasswordDTO> CreatePasswordAsync(PasswordCreateDTO passwordDto, int userId);
    }
}
