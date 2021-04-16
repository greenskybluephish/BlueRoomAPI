using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ArtistDto
    {
        public int ArtistId { get; set; }
        [Required]
        public string ArtistName { get; set; }
        public string Description { get; set; }
        public IEnumerable<IdNameBase> OriginalSongs { get; set; }
        public IEnumerable<ShowDto> Shows { get; set; }

        public IEnumerable<SongPerformance> LiveSongs { get; set; }

    }
}
