using System.ComponentModel.DataAnnotations;
using Entities.Enumerations;

namespace Entities.DataTranferObjects.ExternalMediaObjectDto
{
    public abstract class ExternalMediaObjectForManipulationDto
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public MediaType Type { get; set; }
    }
}