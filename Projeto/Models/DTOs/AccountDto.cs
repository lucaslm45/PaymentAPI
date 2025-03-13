using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Models.DTOs {
    [SwaggerSchema(Title = "Account")]
    public class AccountDto {
        [Required]
        public string Id { get; set; }
        [Required]
        public decimal Balance { get; set; }
    }
}
