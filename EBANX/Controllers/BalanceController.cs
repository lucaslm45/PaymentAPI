using EBANX.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EBANX.Controllers {
    [ApiController]
    [Route("balance")]
    //[Produces("application/json")]
    [ProducesResponseType(200)]
    public class BalanceController : ControllerBase {

        protected readonly IBankService _service;

        public BalanceController(IBankService service) {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(404)]
        public virtual async Task<IActionResult> Balance([FromQuery, Required] string account_id) {
            return await _service.Balance(account_id);
        }
    }
}
