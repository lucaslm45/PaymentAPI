using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models.DTOs {
    /// <summary>
    /// DTO que representa uma transação de depósito.
    /// </summary>
    [SwaggerSchema(Title = "Deposit")]
    public class DepositDto {
        /// <summary>
        /// Conta de destino onde o valor será depositado.
        /// </summary>
        [Required]
        public required AccountDto Destination { get; set; }
    }
}