using PaymentAPI.Business.Services;
using PaymentAPI.Business.Services.Interfaces;

namespace PaymentAPI.Business {
    public static class DIBusiness {
        /// <summary>
        /// Performs dependency injection for the services required in the application.
        /// </summary>
        /// <param name="services">The collection of services where dependencies will be registered.</param>
        /// <remarks>
        /// This method configures the application services so that they can be injected into classes that
        /// require them. It uses the Transient lifecycle for the services, which means
        /// a new instance will be created each time the service is requested.
        /// </remarks>
        public static void AddServices(IServiceCollection services) {
            // Registers the bank operation service
            services.AddTransient<IBankService, BankService>();

            // Registers the event processing service
            services.AddTransient<IEventService, EventService>();

            // Registers the database reset service
            services.AddTransient<IResetService, ResetService>();
        }
    }
}
