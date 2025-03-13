using Projeto.Data.Repositories;
using Projeto.Data.Repositories.Interfaces;

namespace Projeto.Data.DIRepository {
    public static class DIRepository {
        public static void AddRepositories(IServiceCollection services) {
            // Registrar os repositorio
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
        }
    }
}