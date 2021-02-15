using System.ComponentModel.DataAnnotations;

namespace Entities.DataTranferObjects.LocaleDto
{
    public abstract class LocaleForManipulationDto
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
    }
}