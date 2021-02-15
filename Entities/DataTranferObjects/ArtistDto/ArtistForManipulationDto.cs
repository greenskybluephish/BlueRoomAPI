using System.ComponentModel.DataAnnotations;

namespace Entities.DataTranferObjects.ArtistDto
{
    public abstract class ArtistForManipulationDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}