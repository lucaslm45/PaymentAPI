using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models.DTOs {
    /// <summary>
    /// DTO representing a deposit transaction.
    /// </summary>
    [SwaggerSchema(Title = "Deposit")]
    public class DepositDto {
        /// <summary>
        /// Destination account where the amount will be deposited.
        /// </summary>
        [Required]
        public required AccountDto Destination { get; set; }
    }
}