using PaymentAPI.Data.Repositories.Interfaces;
using PaymentAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace PaymentAPI.Data.Repositories {
    /// <summary>
    /// Repositório responsável por gerenciar operações no banco de dados para a entidade AccountEntity.
    /// </summary>
    public class AccountRepository : IAccountRepository {
        private readonly AppDbContext _context;
        private readonly DbSet<AccountEntity> _dbSet;

        /// <summary>
        /// Inicializa uma nova instância de AccountRepository com o contexto do banco de dados.
        /// </summary>
        /// <param name="context">O contexto do banco de dados.</param>
        public AccountRepository(AppDbContext context) {
            _context = context;
            _dbSet = _context.Set<AccountEntity>();
        }

        /// <summary>
        /// Obtém uma conta pelo ID.
        /// </summary>
        /// <param name="accountId">O identificador único da conta.</param>
        /// <returns>Retorna a conta se encontrada, caso contrário, null.</returns>
        public async Task<AccountEntity?> GetById(string accountId) {
            return await _dbSet.FindAsync(accountId);
        }

        /// <summary>
        /// Cria uma nova conta no banco de dados.
        /// </summary>
        /// <param name="entity">A entidade da conta a ser criada.</param>
        /// <returns>Retorna a conta criada.</returns>
        public async Task<AccountEntity> Create(AccountEntity entity) {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Atualiza uma conta existente no banco de dados.
        /// </summary>
        /// <param name="entity">A entidade da conta a ser atualizada.</param>
        /// <returns>Retorna a conta atualizada.</returns>
        public async Task<AccountEntity> Update(AccountEntity entity) {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
