using PaymentAPI.Data.Repositories.Interfaces;
using PaymentAPI.Models.Entities;

namespace PaymentAPI.Data.Repositories.DIRepository {
    /// <summary>
    /// Class responsible for configuring the dependency injection of data repositories.
    /// </summary>
    public static class DIRepository {
        /// <summary>
        /// Registers the repositories in the dependency injection container.
        /// </summary>
        /// <param name="services">The service collection to register the dependencies.</param>
        public static void AddRepositories(IServiceCollection services) {
            // Registers the repositories so they can be injected when needed
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IAccountTransactionRepository, AccountTransactionRepository>();
        }
    }
}
