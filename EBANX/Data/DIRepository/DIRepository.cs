using EBANX.Data.Repositories;
using EBANX.Data.Repositories.Interfaces;

namespace EBANX.Data.DIRepository {
    public static class DIRepository {
        public static void AddRepositories(IServiceCollection services) {
            // Registrar os repositorio
            services.AddTransient<IAccountRepository, AccountRepository>();
        }
    }
}