using System.ComponentModel.DataAnnotations;

namespace Entities.DataTranferObjects.SongDto
{
    public abstract class SongForManipulationDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

    }
}