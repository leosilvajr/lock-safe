using LockSafe.Application.DTOs;

namespace LockSafe.Application.Services.Interface
{
    public interface IUserService
    {
        Task CreateUser(UserCreateDTO userDto);
    }
}
