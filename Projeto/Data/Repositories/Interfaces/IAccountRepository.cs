using Projeto.Models.Entities;

namespace Projeto.Data.Repositories.Interfaces {
    public interface IAccountRepository {

        /// <summary>
        /// Cria uma nova conta no banco de dados.
        /// </summary>
        /// <param name="entity">A conta a ser criada.</param>
        /// <returns>Retorna a conta criada.</returns>
        Task<AccountEntity> Create(AccountEntity entity);

        /// <summary>
        /// Obtém uma conta pelo ID.
        /// </summary>
        /// <param name="accountId">O identificador único da conta.</param>
        /// <returns>Retorna a conta se encontrada, caso contrário, null.</returns>
        Task<AccountEntity?> GetById(string accountId);

        /// <summary>
        /// Atualiza uma conta existente.
        /// </summary>
        /// <param name="entity">A conta com os dados atualizados.</param>
        /// <returns>Retorna a conta atualizada.</returns>
        Task<AccountEntity> Update(AccountEntity entity);
    }
}
