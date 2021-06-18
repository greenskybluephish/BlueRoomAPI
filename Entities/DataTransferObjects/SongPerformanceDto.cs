using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DataTransferObjects
{
    public class SongPerformanceDto
    {
        [Key] [Column("SongPerformanceId")] public int SongPerformanceId { get; set; }

        [Required] 
        public string SetNumberName { get; set; }

        [Required] 
        public int ShowSongIndex { get; set; }
        public string SongPerformanceName { get; set; }
        public int? Duration { get; set; }
        public int? MediaLinkId { get; set; }

        [Required]
        public int ShowId { get; set; }
        [Required] 
        public int SongId { get; set; }
        public string SongName { get; set; }

    }
}
