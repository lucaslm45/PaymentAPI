using Projeto.Business.Services;
using Projeto.Business.Services.Interfaces;

namespace Projeto.Business {
    public static class DIBusiness {
        public static void AddServices(IServiceCollection services) {
            // Registrar os servicos
            services.AddTransient<IBankService, BankService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IResetService, ResetService>();
        }
    }
}
