using Projeto.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Controllers {
    /// <summary>
    /// Controlador responsável pela implementação do endpoint associado à consulta de saldo em conta.
    /// </summary>
    [ApiController]
    [Route("balance")]
    [Produces("application/json")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public class BalanceController : ControllerBase {

        protected readonly IBankService _service;

        /// <summary>
        /// Cria os objetos necessários para o controlador, injetando o serviço de operações bancárias.
        /// </summary>
        /// <param name="service">O serviço que lida com as operações bancárias, como consulta de saldo.</param>
        public BalanceController(IBankService service) {
            _service = service;
        }

        /// <summary>
        /// Aciona o serviço para realizar a consulta do saldo da conta bancária.
        /// </summary>
        /// <param name="account_id">O identificador único da conta bancária para a qual o saldo será consultado.</param>
        /// <returns>
        /// Retorna um <see cref="IActionResult"/> com o saldo da conta ou um erro caso a conta não seja encontrada.
        /// </returns>
        /// <response code="200">Saldo consultado com sucesso.</response>
        /// <response code="404">Conta não encontrada ou identificador inválido fornecido.</response>
        [HttpGet]
        public virtual async Task<IActionResult> Balance([FromQuery, Required] string account_id) {
            return await _service.Balance(account_id);
        }
    }
}
