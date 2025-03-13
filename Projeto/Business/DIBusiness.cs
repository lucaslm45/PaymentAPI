using Projeto.Business.Services;
using Projeto.Business.Services.Interfaces;

namespace Projeto.Business {
    public static class DIBusiness {
        /// <summary>
        /// Realiza a injeção de dependência para os serviços necessários na aplicação.
        /// </summary>
        /// <param name="services">Coleção de serviços onde as dependências serão registradas.</param>
        /// <remarks>
        /// Este método configura os serviços da aplicação para que possam ser injetados nas classes que 
        /// necessitam deles. Utiliza o ciclo de vida <see cref="Transient"/> para os serviços, o que significa 
        /// que uma nova instância será criada a cada vez que o serviço for solicitado.
        /// </remarks>
        public static void AddServices(IServiceCollection services) {
            // Registra o serviço de operações bancárias
            services.AddTransient<IBankService, BankService>();

            // Registra o serviço de processamento de eventos
            services.AddTransient<IEventService, EventService>();

            // Registra o serviço de reset do banco de dados
            services.AddTransient<IResetService, ResetService>();
        }
    }
}
