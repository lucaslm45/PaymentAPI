using PaymentAPI.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PaymentAPI.Controllers {
    /// <summary>
    /// Controller responsible for implementing the endpoint to perform the database reset (cleaning).
    /// </summary>
    [ApiController]
    [Route("reset")]
    [Produces("text/plain")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ResetController : ControllerBase {
        private readonly IResetService _service;

        /// <summary>
        /// Constructor that injects the service responsible for performing the database reset.
        /// </summary>
        /// <param name="service">Service that performs the database reset operation.</param>
        public ResetController(IResetService service) {
            _service = service;
        }

        /// <summary>
        /// Triggers the service to perform the database reset (cleaning).
        /// The reset operation deletes all data and recreates the database tables.
        /// </summary>
        /// <returns>
        /// Returns an <see cref="IResult"/> indicating the status of the reset operation.
        /// </returns>
        /// <response code="200">Database reset completed successfully.</response>
        [HttpPost]
        [ProducesResponseType(200)]
        public IResult Reset() {
            return _service.Reset();
        }
    }
}
