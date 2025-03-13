using EBANX.Business.Services.Interfaces;
using EBANX.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace EBANX.Controllers {
    [ApiController]
    [Route("reset")]
    [Produces("application/json")]
    public class ResetController : ControllerBase {
        //private readonly IResetService _service;

        private readonly AppDbContext _context;

        public ResetController(AppDbContext context) {
            _context = context;
        }
        // Reseta todas as contas e transações
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult ResetState() {

            // Limpa todas as contas e transações no banco In-Memory
            _context.Accounts.RemoveRange(_context.Accounts);
            _context.Transactions.RemoveRange(_context.Transactions);

            // Salva as mudanças, o que efetivamente "limpa" o banco de dados
            _context.SaveChanges();

            return Ok(); // Retorna 200 OK quando o reset for feito
        }
    }
}
