using Projeto.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Models.Entities {
    /// <summary>
    /// Representa uma transação bancária, como depósito, saque ou transferência.
    /// </summary>
    public class TransactionEntity {
        /// <summary>
        /// Identificador único da transação.
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Identificador da conta de origem. Pode ser nulo no caso de depósito.
        /// </summary>
        public string? OriginId { get; set; }

        /// <summary>
        /// Identificador da conta de destino. Pode ser nulo no caso de saque.
        /// </summary>
        public string? DestinationId { get; set; }

        /// <summary>
        /// Valor da transação.
        /// </summary>
        [Required]
        public required decimal Amount { get; set; }

        /// <summary>
        /// Tipo da transação (Depósito, Saque ou Transferência).
        /// </summary>
        [Required]
        public required ETypeEvent Type { get; set; }

        /// <summary>
        /// Data e hora em que a transação foi criada.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Relações com as entidades de contas bancárias
        /// <summary>
        /// Conta de origem da transação, caso haja.
        /// </summary>
        [ForeignKey("OriginId")]
        public AccountEntity? Origin { get; set; }

        /// <summary>
        /// Conta de destino da transação, caso haja.
        /// </summary>
        [ForeignKey("DestinationId")]
        public AccountEntity? Destination { get; set; }
    }
}
