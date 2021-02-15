using System.ComponentModel.DataAnnotations;

namespace Entities.DataTranferObjects.VenueDto
{
    public abstract class VenueForManipulationDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

    }
}