using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SongDto
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        public string Description { get; set; }

        [Required] public int OriginalArtistId { get; set; }

        public ArtistDto OriginalArtist { get; set; }
        public ICollection<ExternalMediaObjectDto> ExternalMediaObjects { get; set; }
        public ICollection<SongPerformanceDto> SongPerformances { get; set; }
    }
}
