using Projeto.Data.Repositories;
using Projeto.Data.Repositories.Interfaces;

namespace Projeto.Data.DIRepository {
    public static class DIRepository {
        /// <summary>
        /// Realiza a Injecao de Dependencia para os Repositorios
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepositories(IServiceCollection services) {
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
        }
    }
}