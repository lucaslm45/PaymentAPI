using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models.Entities {
    /// <summary>
    /// Represents a bank transaction, such as a deposit, withdrawal, or transfer.
    /// </summary>
    public class TransactionEntity {
        /// <summary>
        /// Unique identifier for the transaction.
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Amount of the transaction.
        /// </summary>
        [Required]
        public required decimal Amount { get; set; }

        /// <summary>
        /// The date and time when the transaction was created.
        /// </summary>
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public ICollection<AccountTransactionEntity> AccountTransaction { get; set; } = new List<AccountTransactionEntity>();
    }
}