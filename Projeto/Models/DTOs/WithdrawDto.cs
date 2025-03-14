using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Models.DTOs {
    /// <summary>
    /// DTO que representa os detalhes de um saque bancário.
    /// </summary>
    [SwaggerSchema(Title = "Withdraw")]
    public class WithdrawDto {
        /// <summary>
        /// Conta de origem do saque.
        /// </summary>
        [Required]
        public required AccountDto Origin { get; set; }
    }
}
