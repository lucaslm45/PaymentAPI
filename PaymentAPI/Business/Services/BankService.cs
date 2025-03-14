using PaymentAPI.Business.Services.Interfaces;
using PaymentAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PaymentAPI.Business.Services {
    /// <summary>
    /// Servico responsavel por operacoes bancarias, como consulta de saldo.
    /// </summary>
    public class BankService : IBankService {
        private readonly IAccountRepository _repository;

        /// <summary>
        /// Inicializa uma nova instancia do <see cref="BankService"/>.
        /// </summary>
        /// <param name="repository">Repositorio responsavel pelo acesso aos dados das contas.</param>
        public BankService(IAccountRepository repository) {
            _repository = repository;
        }

        /// <summary>
        /// Consulta o saldo de uma conta bancaria com base no ID fornecido.
        /// </summary>
        /// <param name="accountId">O identificador unico da conta bancaria.</param>
        /// <returns>
        /// Um <see cref="IActionResult"/> contendo o saldo da conta se encontrada, 
        /// ou um erro 404 com saldo zero caso a conta nao exista.
        /// </returns>
        public async Task<IActionResult> Balance(string accountId) {
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
