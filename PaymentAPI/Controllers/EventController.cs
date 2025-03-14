using PaymentAPI.Business.Services.Interfaces;
using PaymentAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Controllers {
    /// <summary>
    /// Controlador responsável pela implementação do endpoint que lida com a realização de transações financeiras.
    /// </summary>
    [ApiController]
    [Route("event")]
    [Produces("application/json")]
    public class EventController : ControllerBase {
        private readonly IEventService _service;

        /// <summary>
        /// Cria os objetos necessários para o controlador, injetando o serviço que gerencia transações financeiras.
        /// </summary>
        /// <param name="service">O serviço responsável por processar as transações do tipo Depósito, Saque e Transferência.</param>
        public EventController(IEventService service) {
            _service = service;
        }

        /// <summary>
        /// Aciona o serviço para realizar transações do tipo Depósito, Saque ou Transferência.
        /// </summary>
        /// <param name="eventDto">O objeto que contém os dados necessários para a transação, como o tipo de evento, valor e contas envolvidas.</param>
        /// <returns>
        /// Retorna um <see cref="IActionResult"/> com o status da transação realizada.
        /// </returns>
        /// <response code="201">Transação concluída com sucesso.</response>
        /// <response code="404">Conta não encontrada ou outros erros relacionados à transação.</response>
        [HttpPost]
        [ProducesResponseType(typeof(DepositDto), 201)]  // Retorno de sucesso para o tipo Depósito
        [ProducesResponseType(typeof(WithdrawDto), 201)] // Retorno de sucesso para o tipo Saque
        [ProducesResponseType(typeof(TransferDto), 201)] // Retorno de sucesso para o tipo Transferência
        [ProducesResponseType(404)] // Caso a conta não seja encontrada ou erro relacionado
        public async Task<IActionResult> ProcessEvent([FromBody, Required] EventDto eventDto) {
            return await _service.ProcessEvent(eventDto);
        }
    }
}
