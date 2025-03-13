using Projeto.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Projeto.Controllers {
    [ApiController]
    [Route("reset")]
    [Produces("text/plain")]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class ResetController : ControllerBase {
        private readonly IResetService _service;

        public ResetController(IResetService service) {
            _service = service;
        }
        // Reseta todas as contas e transações
        [HttpPost]
        [ProducesResponseType(200)]
        public IResult Reset() {
            return _service.Reset();
        }
    }
}
