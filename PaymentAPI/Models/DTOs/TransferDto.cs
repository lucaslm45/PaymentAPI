using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models.DTOs {
    /// <summary>
    /// DTO que representa os detalhes de uma transferência bancária.
    /// </summary>
    [SwaggerSchema(Title = "Transfer")]
    public class TransferDto {
        /// <summary>
        /// Conta de origem da transferência.
        /// </summary>
        [Required]
        public required AccountDto Origin { get; set; }

        /// <summary>
        /// Conta de destino da transferência.
        /// </summary>
        [Required]
        public required AccountDto Destination { get; set; }
    }
}
