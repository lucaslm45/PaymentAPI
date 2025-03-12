using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EBANX.Models.DTOs {
    [SwaggerSchema(Title = "Account")]

    public class AccountDto {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Balance { get; set; }
    }
}
