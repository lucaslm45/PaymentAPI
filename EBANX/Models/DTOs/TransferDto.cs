using Swashbuckle.AspNetCore.Annotations;

namespace EBANX.Models.DTOs {
    [SwaggerSchema(Title = "Transfer")]

    public class TransferDto {
        public AccountDto Origin { get; set; }
        public AccountDto Destination { get; set; }
    }
}
