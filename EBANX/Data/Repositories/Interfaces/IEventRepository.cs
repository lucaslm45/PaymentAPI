using EBANX.Models.Entities;

namespace EBANX.Data.Repositories.Interfaces {
    public interface IEventRepository {
        public Task<AccountEntity> Create(AccountEntity account);
        public Task<AccountEntity> GetById(string accountId);
        public Task<AccountEntity> Update(AccountEntity account);
    }
}
