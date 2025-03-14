using Microsoft.AspNetCore.Mvc;

namespace PaymentAPI.Business.Services.Interfaces {
    /// <summary>
    /// Interface responsável por definir operações bancárias essenciais, como consulta de saldo.
    /// </summary>
    public interface IBankService {
        /// <summary>
        /// Obtém o saldo de uma conta bancária com base no ID fornecido.
        /// </summary>
        /// <param name="accountId">O identificador único da conta bancária.</param>
        /// <returns>
        /// Um <see cref="IActionResult"/> representando o resultado da operação.
        /// </returns>
        Task<IActionResult> Balance(string accountId);
    }
}
