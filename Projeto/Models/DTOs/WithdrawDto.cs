using Swashbuckle.AspNetCore.Annotations;

namespace Projeto.Models.DTOs {
    [SwaggerSchema(Title = "Withdraw")]
    public class WithdrawDto {
        public AccountDto Origin { get; set; }
    }
}
