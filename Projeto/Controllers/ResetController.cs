using Projeto.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Projeto.Controllers {
    /// <summary>
    /// Controlador responsável pela implementação do endpoint para realizar a limpeza (reset) do banco de dados.
    /// </summary>
    [ApiController]
    [Route("reset")]
    [Produces("text/plain")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ResetController : ControllerBase {
        private readonly IResetService _service;

        /// <summary>
        /// Construtor que injeta o serviço responsável por realizar a limpeza do banco de dados.
        /// </summary>
        /// <param name="service">Serviço que realiza a operação de reset do banco de dados.</param>
        public ResetController(IResetService service) {
            _service = service;
        }

        /// <summary>
        /// Aciona o serviço para realizar a limpeza (reset) do banco de dados.
        /// A operação de reset exclui todos os dados e recria as tabelas do banco de dados.
        /// </summary>
        /// <returns>
        /// Retorna um <see cref="IResult"/> indicando o status da operação de reset.
        /// </returns>
        /// <response code="200">Limpeza do banco de dados concluída com sucesso.</response>
        [HttpPost]
        [ProducesResponseType(200)]
        public IResult Reset() {
            return _service.Reset();
        }
    }
}