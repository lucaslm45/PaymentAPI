namespace EBANX.Models.Entities {
    public class AccountEntity {
        public required string Id { get; set; }
        public decimal Balance { get; set; } = 0;
        public ICollection<TransactionEntity> Transactions { get; set; } = new List<TransactionEntity>();
    }
}
