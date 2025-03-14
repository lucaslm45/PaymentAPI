using PaymentAPI.Data.Repositories.Interfaces;
using PaymentAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace PaymentAPI.Data.Repositories {
    /// <summary>
    /// Repositório responsável pelas operações no banco de dados para a entidade TransactionEntity.
    /// </summary>
    public class TransactionRepository : ITransactionRepository {
        private readonly AppDbContext _context;
        private readonly DbSet<TransactionEntity> _dbSet;

        /// <summary>
        /// Construtor da classe TransactionRepository.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public TransactionRepository(AppDbContext context) {
            _context = context;
            _dbSet = _context.Set<TransactionEntity>();
        }

        /// <summary>
        /// Obtém uma transação pelo ID.
        /// </summary>
        /// <param name="id">O identificador único da transação.</param>
        /// <returns>Retorna a transação se encontrada, caso contrário, null.</returns>
        public async Task<TransactionEntity> GetById(Guid id) {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Cria uma nova transação no banco de dados.
        /// </summary>
        /// <param name="entity">A entidade da transação a ser criada.</param>
        /// <returns>Retorna a transação criada.</returns>
        public async Task<TransactionEntity> Create(TransactionEntity entity) {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Atualiza uma transação existente no banco de dados.
        /// </summary>
        /// <param name="entity">A entidade da transação a ser atualizada.</param>
        /// <returns>Retorna a transação atualizada.</returns>
        public async Task<TransactionEntity> Update(TransactionEntity entity) {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}