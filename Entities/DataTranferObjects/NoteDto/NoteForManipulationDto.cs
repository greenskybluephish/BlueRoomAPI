using System.ComponentModel.DataAnnotations;

namespace Entities.DataTranferObjects.NoteDto
{
    public abstract class NoteForManipulationDto
    {
        [Required]
        public int Index { get; set; }
        [Required]
        public string Description { get; set; }

    }
}