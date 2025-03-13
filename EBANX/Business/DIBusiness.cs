using EBANX.Business.Services;
using EBANX.Business.Services.Interfaces;

namespace EBANX.Business {
    public static class DIBusiness {
        public static void AddServices(IServiceCollection services) {
            // Registrar os servicos
            services.AddTransient<IBankService, BankService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IResetService, ResetService>();
        }
    }
}
