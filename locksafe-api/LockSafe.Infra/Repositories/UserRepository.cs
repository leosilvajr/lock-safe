using LockSafe.Domain.Models;
using LockSafe.Infra.Context;
using LockSafe.Infra.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace LockSafe.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LockSafeContext _context;

        public UserRepository(LockSafeContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Users user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(); 
        }

        public async Task<Users> GetByUserNameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }

    }
}
