using LockSafe.Domain.Models;

namespace LockSafe.Infra.Repositories.Interface
{
    public interface IPasswordAllowanceRepository
    {
        Task AddAsync(PasswordAllowance allowance);
        Task<PasswordAllowance> GetByPasswordAndUserAsync(int passwordId, int userId);
    }
}
