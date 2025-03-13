using Projeto.Business.Services.Interfaces;
using Projeto.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Projeto.Business.Services {
    public class BankService : IBankService {
        private readonly IAccountRepository _repository;

        public BankService(IAccountRepository repository) {
            _repository = repository;
        }

        public async Task<IActionResult> Balance(string accountId) {
            try {
                //ToDo: adicionar validacaoes para accountId ser do tipo int
                var account = await _repository.GetById(accountId);
                if (account == null)
                    throw new Exception();

                return new OkObjectResult(account.Balance);
            }
            catch (Exception) {
                return new NotFoundObjectResult(0);
            }

        }
    }
}
