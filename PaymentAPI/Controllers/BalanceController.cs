using PaymentAPI.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Controllers {
    /// <summary>
    /// Controller responsible for implementing the endpoint associated with the account balance query.
    /// </summary>
    [ApiController]
    [Route("balance")]
    [Produces("application/json")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public class BalanceController : ControllerBase {

        protected readonly IBankService _service;

        /// <summary>
        /// Creates the necessary objects for the controller, injecting the banking operations service.
        /// </summary>
        /// <param name="service">The service that handles banking operations, such as balance inquiries.</param>
        public BalanceController(IBankService service) {
            _service = service;
        }

        /// <summary>
        /// Triggers the service to perform the bank account balance inquiry.
        /// </summary>
        /// <param name="account_id">The unique identifier of the bank account for which the balance will be queried.</param>
        /// <returns>
        /// Returns an <see cref="IActionResult"/> with the account balance or an error if the account is not found.
        /// </returns>
        /// <response code="200">Balance successfully queried.</response>
        /// <response code="404">Account not found or invalid identifier provided.</response>
        [HttpGet]
        public virtual async Task<IActionResult> Balance([FromQuery, Required] int account_id) {
            return await _service.Balance(account_id);
        }
    }
}
