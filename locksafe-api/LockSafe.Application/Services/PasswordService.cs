using LockSafe.Application.DTOs;
using LockSafe.Application.Helpers;
using LockSafe.Application.Services.Interface;
using LockSafe.Domain.Models;
using LockSafe.Infra.Repositories.Interface;

namespace LockSafe.Application.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordRepository _passwordRepository;
        private readonly IPasswordAllowanceRepository _passwordAllowanceRepository;

        public PasswordService(IPasswordRepository passwordRepository, IPasswordAllowanceRepository passwordAllowanceRepository)
        {
            _passwordRepository = passwordRepository;
            _passwordAllowanceRepository = passwordAllowanceRepository;
        }

        public async Task<PasswordDTO> CreatePasswordAsync(PasswordCreateDTO passwordDto, int userId)
        {
            // Mapear DTO para entidade Password
            var password = new Password();
            password.Title = passwordDto.Title;
            password.Description = passwordDto.Description;
            password.Reference = passwordDto.Reference;
            password.Account = passwordDto.Account;
            password.PasswordValue = CriptografiaHelper.Criptografar(passwordDto.PasswordValue);
            password.CreationDate = DateTime.Now;
            password.ExpirationDate = passwordDto.ExpirationDate;

            // Salvar a senha no banco de dados
            var createdPassword = await _passwordRepository.AddAsync(password);

            // Criar o registro em PasswordAllowance
            var passwordAllowance = new PasswordAllowance
            {
                PasswordId = createdPassword.Id,
                UserId = userId,
                IsAdmin = passwordDto.IsAdmin
            };

            await _passwordAllowanceRepository.AddAsync(passwordAllowance);

            // Retornar os dados criados
            return new PasswordDTO
            {
                Id = createdPassword.Id,
                Title = createdPassword.Title,
                Description = createdPassword.Description,
                Reference = createdPassword.Reference,
                Account = createdPassword.Account,
                PasswordValue = CriptografiaHelper.Criptografar(passwordDto.PasswordValue),
                CreationDate = createdPassword.CreationDate,
                ExpirationDate = createdPassword.ExpirationDate
            };
        }


        //Função para exibir a senha descriptografada, por exemplo, quando o usuário solicitar
        public string GetDescryptedPassword(string senhaCriptografada)
        {
            return CriptografiaHelper.Descriptografar(senhaCriptografada);
        }
    }
}
