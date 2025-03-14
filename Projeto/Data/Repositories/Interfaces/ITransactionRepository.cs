using Projeto.Models.Entities;
using System;
using System.Threading.Tasks;

namespace Projeto.Data.Repositories.Interfaces {
    /// <summary>
    /// Interface responsável por definir as operações no banco de dados para a entidade TransactionEntity.
    /// </summary>
    public interface ITransactionRepository {
        /// <summary>
        /// Cria uma nova transação no banco de dados.
        /// </summary>
        /// <param name="entity">A entidade da transação a ser criada.</param>
        /// <returns>Retorna a transação criada.</returns>
        Task<TransactionEntity> Create(TransactionEntity entity);

        /// <summary>
        /// Obtém uma transação pelo ID.
        /// </summary>
        /// <param name="id">O identificador único da transação.</param>
        /// <returns>Retorna a transação se encontrada, caso contrário, null.</returns>
        Task<TransactionEntity> GetById(Guid id);

        /// <summary>
        /// Atualiza uma transação existente no banco de dados.
        /// </summary>
        /// <param name="entity">A entidade da transação a ser atualizada.</param>
        /// <returns>Retorna a transação atualizada.</returns>
        Task<TransactionEntity> Update(TransactionEntity entity);
    }
}