using PaymentAPI.Data.Repositories.Interfaces;
using PaymentAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace PaymentAPI.Data.Repositories {
    /// <summary>
    /// Repository responsible for database operations for the <see cref="TransactionEntity"/>.
    /// </summary>
    public class TransactionRepository : ITransactionRepository {
        private readonly AppDbContext _context;
        private readonly DbSet<TransactionEntity> _dbSet;

        /// <summary>
        /// Constructor for the TransactionRepository class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public TransactionRepository(AppDbContext context) {
            _context = context;
            _dbSet = _context.Set<TransactionEntity>();
        }

        /// <summary>
        /// Retrieves a transaction by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the transaction.</param>
        /// <returns>Returns the transaction if found, otherwise, null.</returns>
        public async Task<TransactionEntity> GetById(Guid id) {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Creates a new transaction in the database.
        /// </summary>
        /// <param name="entity">The transaction entity to be created.</param>
        /// <returns>Returns the created transaction.</returns>
        public async Task<TransactionEntity> Create(TransactionEntity entity) {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Updates an existing transaction in the database.
        /// </summary>
        /// <param name="entity">The transaction entity to be updated.</param>
        /// <returns>Returns the updated transaction.</returns>
        public async Task<TransactionEntity> Update(TransactionEntity entity) {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
