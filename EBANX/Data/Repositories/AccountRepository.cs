using EBANX.Data.Repositories.Interfaces;
using EBANX.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EBANX.Data.Repositories {
    public class AccountRepository : IAccountRepository {
        private readonly AppDbContext _context;
        private readonly DbSet<AccountEntity> _dbSet;

        public AccountRepository(AppDbContext context) {
            _context = context;
            _dbSet = _context.Set<AccountEntity>();
        }

        public async Task<AccountEntity> GetById(string id) {
            return await _dbSet.FindAsync(id);
        }
    }
}
