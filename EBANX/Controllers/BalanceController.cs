using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EBANX.Controllers {
    [ApiController]
    public class BalanceController : ControllerBase {

        [HttpGet]
        public virtual async Task<IActionResult> GetBalance([FromQuery, Required] string id) {
            return Ok();
            ////var account = _bankService.GetBalance(id);
            //if (account == null) return NotFound(0);
            //return Ok(account.Balance);
        }
    }
}
