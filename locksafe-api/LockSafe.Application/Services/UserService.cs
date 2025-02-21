using LockSafe.Application.DTOs;
using LockSafe.Application.Services.Interface;
using LockSafe.Domain.Models;
using LockSafe.Infra.Repositories.Interface;

namespace LockSafe.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(UserCreateDTO userDto)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto), "Dados do usuário não podem ser nulos.");

            // Fazer hash da senha
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            // Mapear DTO para a entidade
            var user = new Users
            {
                FullName = userDto.FullName,
                UserName = userDto.UserName,
                Email = userDto.Email,
                ProfileImageUrl = userDto.ProfileImageUrl,
                Password = hashedPassword // Salvar senha criptografada
            };

            await _userRepository.AddAsync(user);
        }
    }
}
