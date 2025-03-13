using EBANX.Data.Repositories.Interfaces;
using EBANX.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EBANX.Data.Repositories {
    public class EventRepository : IEventRepository {
        private readonly AppDbContext _context;
        private readonly DbSet<AccountEntity> _dbSet;

        public EventRepository(AppDbContext context) {
            _context = context;
            _dbSet = _context.Set<AccountEntity>();
        }
        public async Task<AccountEntity> GetById(string accountId) {
            return await _context.Accounts.FindAsync(accountId);
        }
        public async Task<AccountEntity> Create(AccountEntity entity) {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<AccountEntity> Update(AccountEntity entity) {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
