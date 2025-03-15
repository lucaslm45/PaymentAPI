using PaymentAPI.Business.Services.Interfaces;
using PaymentAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PaymentAPI.Business.Services {
    /// <summary>
    /// Service responsible for banking operations, such as balance inquiry.
    /// </summary>
    public class BankService : IBankService {
        private readonly IAccountRepository _repository;

        /// <summary>
        /// Initializes a new instance of <see cref="BankService"/>.
        /// </summary>
        /// <param name="repository">Repository responsible for accessing account data.</param>
        public BankService(IAccountRepository repository) {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves the balance of a bank account based on the provided ID.
        /// </summary>
        /// <param name="accountId">The unique identifier of the bank account.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> containing the account balance if found, 
        /// or a 404 error with a zero balance if the account does not exist.
        /// </returns>
        public async Task<IActionResult> Balance(int accountId) {
            try {
                var account = await _repository.GetById(accountId);
                if (account == null)
                    throw new Exception();

                return new OkObjectResult(account.Balance);
            }
            catch (Exception) {
                return new NotFoundObjectResult(0);
            }
        }
    }
}
