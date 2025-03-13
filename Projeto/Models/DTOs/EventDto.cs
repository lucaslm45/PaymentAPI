using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Models.DTOs {
    [SwaggerSchema(Title = "Event")]
    public class EventDto {
        [Required]
        public required string Type { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        [Required]
        public required decimal Amount { get; set; }
    }
}
