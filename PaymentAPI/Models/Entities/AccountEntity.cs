using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models.Entities {
    /// <summary>
    /// Representa uma conta bancária na entidade de dados.
    /// </summary>
    public class AccountEntity {
        /// <summary>
        /// Identificador único da conta bancária.
        /// </summary>
        [Key]
        public required string Id { get; set; }

        /// <summary>
        /// Saldo da conta bancária. O valor padrão é 0.
        /// </summary>
        public decimal Balance { get; set; } = 0;

        /// <summary>
        /// Coleção de transações associadas a esta conta.
        /// </summary>
        public ICollection<TransactionEntity> Transactions { get; set; } = new List<TransactionEntity>();
    }
}
