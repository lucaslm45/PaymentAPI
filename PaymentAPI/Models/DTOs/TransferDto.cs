using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models.DTOs {
    /// <summary>
    /// DTO representing the details of a bank transfer.
    /// </summary>
    [SwaggerSchema(Title = "Transfer")]
    public class TransferDto {
        /// <summary>
        /// The origin account of the transfer.
        /// </summary>
        [Required]
        public required AccountDto Origin { get; set; }

        /// <summary>
        /// The destination account of the transfer.
        /// </summary>
        [Required]
        public required AccountDto Destination { get; set; }
    }
}