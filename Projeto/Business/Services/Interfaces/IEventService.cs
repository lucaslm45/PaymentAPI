using Projeto.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Projeto.Business.Services.Interfaces {
    public interface IEventService {
        Task<IActionResult> ProcessEvent(EventDto eventDto);
    }
}
