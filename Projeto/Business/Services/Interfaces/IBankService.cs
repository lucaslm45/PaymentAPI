using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Projeto.Business.Services.Interfaces {
    public interface IBankService {
        Task<IActionResult> Balance(string accountId);
    }
}
