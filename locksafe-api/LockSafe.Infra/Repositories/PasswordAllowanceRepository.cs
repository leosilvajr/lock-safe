using LockSafe.Domain.Models;
using LockSafe.Infra.Context;
using LockSafe.Infra.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace LockSafe.Infra.Repositories
{
    public class PasswordAllowanceRepository : IPasswordAllowanceRepository
    {
        private readonly LockSafeContext _context;

        public PasswordAllowanceRepository(LockSafeContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PasswordAllowance allowance)
        {
            await _context.PasswordAllowances.AddAsync(allowance);
            await _context.SaveChangesAsync();
        }

        public async Task<PasswordAllowance> GetByPasswordAndUserAsync(int passwordId, int userId)
        {
            return await _context.PasswordAllowances.FirstOrDefaultAsync(pa => pa.PasswordId == passwordId && pa.UserId == userId);
        }
    }
}
