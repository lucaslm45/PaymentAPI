using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models.Entities {
    /// <summary>
    /// Represents a bank account in the data entity.
    /// </summary>
    public class AccountEntity {
        /// <summary>
        /// Unique identifier for the bank account.
        /// </summary>
        [Key]
        public required int Id { get; set; }

        /// <summary>
        /// The balance of the bank account. The default value is 0.
        /// </summary>
        public decimal Balance { get; set; } = 0;

        /// <summary>
        /// Collection of transactions associated with this account.
        /// </summary>
        public ICollection<AccountTransactionEntity> AccountTransaction { get; set; } = new List<AccountTransactionEntity>();
    }
}