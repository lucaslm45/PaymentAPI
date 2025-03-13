using EBANX.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EBANX.Business.Services.Interfaces {
    public interface IEventService {
        Task<IActionResult> ProcessEvent(EventDto eventDto);
    }
}
