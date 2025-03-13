using Swashbuckle.AspNetCore.Annotations;

namespace Projeto.Models.DTOs {
    [SwaggerSchema(Title = "Deposit")]
    public class DepositDto {
        public AccountDto Destination { get; set; }
    }
}
