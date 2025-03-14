//using Projeto.Data.Repositories.Interfaces;
//using Projeto.Models.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace Projeto.Data.Repositories {
//    public class EventRepository : IAccountRepository {
//        private readonly AppDbContext _context;
//        private readonly DbSet<AccountEntity> _dbSet;

//        public EventRepository(AppDbContext context) {
//            _context = context;
//            _dbSet = _context.Set<AccountEntity>();
//        }
//        public async Task<AccountEntity?> GetById(string accountId) {
//            return await _dbSet.FindAsync(accountId);
//        }
//        public async Task<AccountEntity> Create(AccountEntity entity) {
//            await _dbSet.AddAsync(entity);
//            await _context.SaveChangesAsync();
//            return entity;
//        }

//        public async Task<AccountEntity> Update(AccountEntity entity) {
//            _dbSet.Update(entity);
//            await _context.SaveChangesAsync();

//            return entity;
//        }
//    }
//}
