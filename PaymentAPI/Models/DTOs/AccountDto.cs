using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models.DTOs {
    /// <summary>
    /// DTO representing an account in the system.
    /// </summary>
    [SwaggerSchema(Title = "Account")]
    public class AccountDto {
        /// <summary>
        /// Unique identifier for the account.
        /// </summary>
        [Required]
        public required string Id { get; set; }

        /// <summary>
        /// Available balance in the account.
        /// </summary>
        [Required]
        public decimal Balance { get; set; }
    }
}