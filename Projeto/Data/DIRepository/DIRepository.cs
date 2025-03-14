using Projeto.Data.Repositories;
using Projeto.Data.Repositories.Interfaces;

namespace Projeto.Data.DIRepository {
    /// <summary>
    /// Classe responsável por configurar a injeção de dependência dos repositórios de dados.
    /// </summary>
    public static class DIRepository {
        /// <summary>
        /// Registra os repositórios no container de injeção de dependência.
        /// </summary>
        /// <param name="services">Coleção de serviços para registrar as dependências.</param>
        public static void AddRepositories(IServiceCollection services) {
            // Registra os repositórios para que possam ser injetados quando necessário
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
        }
    }
}
