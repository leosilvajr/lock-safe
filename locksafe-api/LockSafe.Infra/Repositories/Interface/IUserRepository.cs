using LockSafe.Domain.Models;

namespace LockSafe.Infra.Repositories.Interface
{
    public interface IUserRepository
    {
        Task AddAsync(Users user);
        Task<Users> GetByUserNameAsync(string userName);
    }
}
