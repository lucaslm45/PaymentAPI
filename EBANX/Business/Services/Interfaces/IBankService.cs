using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace EBANX.Business.Services.Interfaces {
    public interface IBankService {
        Task<IActionResult> Balance(string accountId);
    }
}
