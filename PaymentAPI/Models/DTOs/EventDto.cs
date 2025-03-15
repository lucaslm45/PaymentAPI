using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models.DTOs {
    /// <summary>
    /// DTO that represents the details of a banking event (e.g., deposit, withdrawal, transfer).
    /// </summary>
    [SwaggerSchema(Title = "Event")]
    public class EventDto {
        /// <summary>
        /// Event type (e.g., "Deposit", "Withdraw", "Transfer").
        /// </summary>
        [Required]
        public required string Type { get; set; }

        /// <summary>
        /// Source account (applicable for transfer or withdraw).
        /// </summary>
        public int Origin { get; set; } = 0;

        /// <summary>
        /// Destination account (applicable for deposit or transfer).
        /// </summary>
        public int Destination { get; set; } = 0;

        /// <summary>
        /// Amount involved in the event (e.g., deposit, withdraw, or transfer amount).
        /// </summary>
        [Required]
        public required decimal Amount { get; set; }
    }
}
