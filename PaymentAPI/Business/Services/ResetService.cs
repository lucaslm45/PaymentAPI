using PaymentAPI.Business.Services.Interfaces;
using PaymentAPI.Data;

namespace PaymentAPI.Business.Services {
    public class ResetService : IResetService {
        private readonly AppDbContext _context;
        //private readonly IWebHostEnvironment _env;

        /// <summary>
        /// Inicializa uma nova instância do <see cref="ResetService"/> com a injeção do contexto do banco de dados.
        /// </summary>
        /// <param name="context">O contexto do banco de dados utilizado para gerenciar a persistência dos dados.</param>
        public ResetService(AppDbContext context) {
            _context = context;
            //_env = env;
        }

        /// <summary>
        /// Reseta o banco de dados, excluindo e recriando todas as tabelas.
        /// </summary>
        /// <returns>Um resultado HTTP indicando sucesso ou falha na operação.</returns>
        public IResult Reset() {
            try {
                // Exclui e recria o banco de dados para garantir um estado inicial limpo.
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();

                return Results.Content("OK", "text/plain");
            }
            catch (Exception) {
                // Retorna um erro caso a operação falhe.
                return Results.NotFound();
            }
        }
    }
}
