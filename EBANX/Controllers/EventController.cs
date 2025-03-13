using EBANX.Business.Services.Interfaces;
using EBANX.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EBANX.Controllers {
    [ApiController]
    [Route("event")]
    [Produces("application/json")]
    public class EventController : ControllerBase {
        private readonly IEventService _service;

        public EventController(IEventService service) {
            _service = service;
        }
        [HttpPost]
        [ProducesResponseType(typeof(DepositDto), 201)] // Depósito
        [ProducesResponseType(typeof(WithdrawDto), 201)] // Saque
        [ProducesResponseType(typeof(TransferDto), 201)] // Transferência
        [ProducesResponseType(404)]
        public async Task<IActionResult> ProcessEvent([FromBody, Required] EventDto eventDto) {
            return await _service.ProcessEvent(eventDto);
        }
    }
}
