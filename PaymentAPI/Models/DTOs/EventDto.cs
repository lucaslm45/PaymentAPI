using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models.DTOs {
    /// <summary>
    /// DTO que representa os detalhes de um evento bancário (ex: depósito, saque, transferência).
    /// </summary>
    [SwaggerSchema(Title = "Event")]
    public class EventDto {
        /// <summary>
        /// Tipo de evento (ex: "Deposit", "Withdraw", "Transfer").
        /// </summary>
        [Required]
        public required string Type { get; set; }

        /// <summary>
        /// Conta de origem (aplicável para transferência ou saque).
        /// </summary>
        public string? Origin { get; set; }

        /// <summary>
        /// Conta de destino (aplicável para depósito ou transferência).
        /// </summary>
        public string? Destination { get; set; }

        /// <summary>
        /// Quantidade envolvida no evento (ex: valor do depósito, saque, ou transferência).
        /// </summary>
        [Required]
        public required decimal Amount { get; set; }
    }
}
