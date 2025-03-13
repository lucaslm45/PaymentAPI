using Projeto.Business.Services.Interfaces;
using Projeto.Data;
using Microsoft.AspNetCore.Mvc;

namespace Projeto.Business.Services {
    public class ResetService : IResetService {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ResetService(AppDbContext context, IWebHostEnvironment env) {
            _context = context;
            _env = env;
        }

        public IResult Reset() {
            try {
                // Verifique se o ambiente é de teste
                if (!_env.IsDevelopment() && !_env.IsEnvironment("Test"))
                    throw new InvalidOperationException();

                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();

                return Results.Content("OK", "text/plain");
            }
            catch (Exception) {
                return Results.NotFound();
            }
        }
    }
}
