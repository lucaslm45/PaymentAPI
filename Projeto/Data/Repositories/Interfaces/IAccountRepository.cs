using Projeto.Models.Entities;

namespace Projeto.Data.Repositories.Interfaces {
    public interface IAccountRepository {
        Task<AccountEntity> GetById(string id);
    }
}
