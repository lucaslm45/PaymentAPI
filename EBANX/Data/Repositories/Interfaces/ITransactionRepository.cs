using EBANX.Models.Entities;

namespace EBANX.Data.Repositories.Interfaces {
    public interface ITransactionRepository {
        public Task<TransactionEntity> Create(TransactionEntity entity);
        public Task<TransactionEntity> GetById(Guid id);
        public Task<TransactionEntity> Update(TransactionEntity entity);
    }
}
