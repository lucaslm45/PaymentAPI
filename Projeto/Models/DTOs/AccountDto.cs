using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Models.DTOs {
    /// <summary>
    /// DTO que representa uma conta no sistema.
    /// </summary>
    [SwaggerSchema(Title = "Account")]
    public class AccountDto {
        /// <summary>
        /// Identificador único da conta.
        /// </summary>
        [Required]
        public required string Id { get; set; }

        /// <summary>
        /// Saldo disponível na conta.
        /// </summary>
        [Required]
        public decimal Balance { get; set; }
    }
}