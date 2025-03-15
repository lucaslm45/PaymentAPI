using PaymentAPI.Models.Entities;

namespace PaymentAPI.Data.Repositories.Interfaces {
    public interface IAccountRepository {

        /// <summary>
        /// Creates a new account in the database.
        /// </summary>
        /// <param name="entity">The account to be created.</param>
        /// <returns>Returns the created account.</returns>
        Task<AccountEntity> Create(AccountEntity entity);

        /// <summary>
        /// Retrieves an account by its ID.
        /// </summary>
        /// <param name="accountId">The unique identifier of the account.</param>
        /// <returns>Returns the account if found, otherwise, null.</returns>
        Task<AccountEntity?> GetById(int accountId);

        /// <summary>
        /// Updates an existing account.
        /// </summary>
        /// <param name="entity">The account with updated data.</param>
        /// <returns>Returns the updated account.</returns>
        Task<AccountEntity> Update(AccountEntity entity);
    }
}