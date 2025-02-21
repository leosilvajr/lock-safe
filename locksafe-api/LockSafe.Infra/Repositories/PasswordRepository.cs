using LockSafe.Domain.Models;
using LockSafe.Infra.Context;
using LockSafe.Infra.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace LockSafe.Infra.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly LockSafeContext _context;

        public PasswordRepository(LockSafeContext context)
        {
            _context = context;
        }

        public async Task<Password> AddAsync(Password password)
        {
            await _context.Passwords.AddAsync(password);
            await _context.SaveChangesAsync();
            return password;
        }

        public async Task<Password> GetByIdAsync(int id)
        {
            return await _context.Passwords.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
