using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data.Repositories.Interfaces;
using PaymentAPI.Models.Entities;

namespace PaymentAPI.Data.Repositories {
    /// <summary>
    /// Repository responsible for database operations for the AccountTransactionEntity.
    /// </summary>
    public class AccountTransactionRepository : IAccountTransactionRepository {
        private readonly AppDbContext _context;
        private readonly DbSet<AccountTransactionEntity> _dbSet;

        /// <summary>
        /// Constructor for the AccountTransactionRepository class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public AccountTransactionRepository(AppDbContext context) {
            _context = context;
            _dbSet = _context.Set<AccountTransactionEntity>();
        }

        /// <summary>
        /// Retrieves an account transaction by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the account transaction.</param>
        /// <returns>Returns the account transaction if found, otherwise, null.</returns>
        //public async Task<AccountTransactionEntity> GetById(Guid id) {
        //    return await _dbSet.FindAsync(id);
        //}

        /// <summary>
        /// Creates a new account transaction in the database.
        /// </summary>
        /// <param name="entity">The account transaction entity to be created.</param>
        /// <returns>Returns the created account transaction.</returns>
        public async Task<AccountTransactionEntity> Create(AccountTransactionEntity entity) {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Updates an existing account transaction in the database.
        /// </summary>
        /// <param name="entity">The account transaction entity to be updated.</param>
        /// <returns>Returns the updated account transaction.</returns>
        public async Task<AccountTransactionEntity> Update(AccountTransactionEntity entity) {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}