using EBANX.Data.Repositories.Interfaces;
using EBANX.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EBANX.Data.Repositories {
    public class TransactionRepository : ITransactionRepository {
        private readonly AppDbContext _context;
        private readonly DbSet<TransactionEntity> _dbSet;

        public TransactionRepository(AppDbContext context) {
            _context = context;
            _dbSet = _context.Set<TransactionEntity>();
        }
        public async Task<TransactionEntity> GetById(Guid id) {
            return await _context.Transactions.FindAsync(id);
        }
        public async Task<TransactionEntity> Create(TransactionEntity entity) {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TransactionEntity> Update(TransactionEntity entity) {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
