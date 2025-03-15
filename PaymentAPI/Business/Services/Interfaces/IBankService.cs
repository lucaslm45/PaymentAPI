using Microsoft.AspNetCore.Mvc;

namespace PaymentAPI.Business.Services.Interfaces {
    /// <summary>
    /// Interface responsible for defining essential banking operations, such as balance inquiries.
    /// </summary>
    public interface IBankService {
        /// <summary>
        /// Retrieves the balance of a bank account based on the provided ID.
        /// </summary>
        /// <param name="accountId">The unique identifier of the bank account.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> representing the result of the operation.
        /// </returns>
        Task<IActionResult> Balance(int accountId);
    }
}