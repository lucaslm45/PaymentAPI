using Swashbuckle.AspNetCore.Annotations;

namespace EBANX.Models.DTOs {
    [SwaggerSchema(Title = "Withdraw")]
    public class WithdrawDto {
        public AccountDto Origin { get; set; }
    }
}
