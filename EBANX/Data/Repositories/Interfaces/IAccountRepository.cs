using EBANX.Models.Entities;

namespace EBANX.Data.Repositories.Interfaces {
    public interface IAccountRepository {
        Task<AccountEntity> GetById(string id);
    }
}
