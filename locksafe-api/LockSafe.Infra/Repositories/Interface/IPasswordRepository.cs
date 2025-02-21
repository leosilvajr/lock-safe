using LockSafe.Domain.Models;

namespace LockSafe.Infra.Repositories.Interface
{
    public interface IPasswordRepository
    {
        Task<Password> AddAsync(Password password);
        Task<Password> GetByIdAsync(int id);
    }
}
