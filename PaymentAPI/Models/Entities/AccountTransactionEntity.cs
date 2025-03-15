using PaymentAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models.Entities {
    public class AccountTransactionEntity {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Account identifier.
        /// </summary>
        [Required]
        public required int AccountId { get; set; }

        /// <summary>
        /// Transaction identifier.
        /// </summary>
        [Required]
        public required Guid TransactionId { get; set; }

        /// <summary>
        /// Transaction type (Deposit, Withdraw).
        /// </summary>
        [Required]
        public required ETypeEvent Type { get; set; }

        /// <summary>
        /// Account reference.
        /// </summary>
        public AccountEntity Account { get; set; }

        /// <summary>
        /// Transaction reference.
        /// </summary>
        public TransactionEntity Transaction { get; set; }
    }
}
