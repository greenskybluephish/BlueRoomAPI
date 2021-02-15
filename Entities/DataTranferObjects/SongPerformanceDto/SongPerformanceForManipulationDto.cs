using System.ComponentModel.DataAnnotations;
using Entities.Enumerations;

namespace Entities.DataTranferObjects.SongPerformanceDto
{
    public abstract class SongPerformanceForManipulationDto
    {
        [Required]
        public SetNumber SetIndex { get; set; }
        [Required]
        public int SetlistSongIndex { get; set; }
        public int? Duration { get; set; }

    }
}