using PaymentAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace PaymentAPI.Business.Services.Interfaces {
    /// <summary>
    /// Define a interface para o serviço de processamento de eventos financeiros.
    /// </summary>
    public interface IEventService {
        /// <summary>
        /// Processa um evento financeiro com base no tipo de transação informada.
        /// </summary>
        /// <param name="eventDto">Objeto contendo os dados do evento a ser processado.</param>
        /// <returns>
        /// Um <see cref="IActionResult"/> representando o resultado da operação.
        /// </returns>
        Task<IActionResult> ProcessEvent(EventDto eventDto);
    }
}
