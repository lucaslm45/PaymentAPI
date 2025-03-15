using PaymentAPI.Business.Services.Interfaces;
using PaymentAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Controllers {
    /// <summary>
    /// Controller responsible for implementing the endpoint that handles financial transactions.
    /// </summary>
    [ApiController]
    [Route("event")]
    [Produces("application/json")]
    public class EventController : ControllerBase {
        private readonly IEventService _service;

        /// <summary>
        /// Creates the necessary objects for the controller, injecting the service that manages financial transactions.
        /// </summary>
        /// <param name="service">The service responsible for processing transactions such as Deposit, Withdrawal, and Transfer.</param>
        public EventController(IEventService service) {
            _service = service;
        }

        /// <summary>
        /// Triggers the service to perform transactions of type Deposit, Withdrawal, or Transfer.
        /// </summary>
        /// <param name="eventDto">The object containing the necessary data for the transaction, such as event type, value, and involved accounts.</param>
        /// <returns>
        /// Returns an <see cref="IActionResult"/> with the status of the transaction.
        /// </returns>
        /// <response code="201">Transaction completed successfully.</response>
        /// <response code="404">Account not found or other errors related to the transaction.</response>
        [HttpPost]
        [ProducesResponseType(typeof(DepositDto), 201)]  // Success response for Deposit type
        [ProducesResponseType(typeof(WithdrawDto), 201)] // Success response for Withdraw type
        [ProducesResponseType(typeof(TransferDto), 201)] // Success response for Transfer type
        [ProducesResponseType(404)] // In case the account is not found or another related error occurs
        public async Task<IActionResult> ProcessEvent([FromBody, Required] EventDto eventDto) {
            return await _service.ProcessEvent(eventDto);
        }
    }
}
