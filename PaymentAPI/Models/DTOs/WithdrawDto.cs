using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models.DTOs {
    /// <summary>
    /// DTO representing the details of a bank withdrawal.
    /// </summary>
    [SwaggerSchema(Title = "Withdraw")]
    public class WithdrawDto {
        /// <summary>
        /// The origin account of the withdrawal.
        /// </summary>
        [Required]
        public required AccountDto Origin { get; set; }
    }
}