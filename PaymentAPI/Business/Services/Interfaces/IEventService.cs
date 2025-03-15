using PaymentAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace PaymentAPI.Business.Services.Interfaces {
    /// <summary>
    /// Defines the interface for the financial event processing service.
    /// </summary>
    public interface IEventService {
        /// <summary>
        /// Processes a financial event based on the specified transaction type.
        /// </summary>
        /// <param name="eventDto">Object containing the event data to be processed.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> representing the result of the operation.
        /// </returns>
        Task<IActionResult> ProcessEvent(EventDto eventDto);
    }
}
