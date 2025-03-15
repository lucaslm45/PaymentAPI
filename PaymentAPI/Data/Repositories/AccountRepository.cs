using PaymentAPI.Data.Repositories.Interfaces;
using PaymentAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace PaymentAPI.Data.Repositories {
    /// <summary>
    /// Repository responsible for managing database operations for the <see cref="AccountEntity"/>.
    /// </summary>
    public class AccountRepository : IAccountRepository {
        private readonly AppDbContext _context;
        private readonly DbSet<AccountEntity> _dbSet;

        /// <summary>
        /// Initializes a new instance of AccountRepository with the database context.
        /// </summary>
        /// <param name="context">The database context.</param>
        public AccountRepository(AppDbContext context) {
            _context = context;
            _dbSet = _context.Set<AccountEntity>();
        }

        /// <summary>
        /// Retrieves an account by its ID.
        /// </summary>
        /// <param name="accountId">The unique identifier of the account.</param>
        /// <returns>Returns the account if found, otherwise, null.</returns>
        public async Task<AccountEntity?> GetById(int accountId) {
            return await _dbSet.FindAsync(accountId);
        }

        /// <summary>
        /// Creates a new account in the database.
        /// </summary>
        /// <param name="entity">The account entity to be created.</param>
        /// <returns>Returns the created account.</returns>
        public async Task<AccountEntity> Create(AccountEntity entity) {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Updates an existing account in the database.
        /// </summary>
        /// <param name="entity">The account entity to be updated.</param>
        /// <returns>Returns the updated account.</returns>
        public async Task<AccountEntity> Update(AccountEntity entity) {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}