using EBANX.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBANX.Models.Entities {
    public class TransactionEntity {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? OriginId { get; set; }  // Pode ser nulo em caso de depósito
        public string? DestinationId { get; set; }  // Pode ser nulo em caso de saque

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public ETypeEvent Type { get; set; }  // Define se é deposit, saque ou transfer

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Relações com contas bancárias
        [ForeignKey("OriginId")]
        public AccountEntity? Origin { get; set; }

        [ForeignKey("DestinationId")]
        public AccountEntity? Destination { get; set; }
    }
}
