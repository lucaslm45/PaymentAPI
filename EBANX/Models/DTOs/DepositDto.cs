using Swashbuckle.AspNetCore.Annotations;

namespace EBANX.Models.DTOs {
    [SwaggerSchema(Title = "Deposit")]
    public class DepositDto {
        public AccountDto Destination { get; set; }
    }
}
