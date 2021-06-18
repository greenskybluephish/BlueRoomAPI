using Entities.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class ArtistDto
    {

        public ArtistDto()
        {

        }

        public ArtistDto(Artist artist)
        {
            ArtistId = artist.ArtistId;
            ArtistName = artist.Name;
        }

        public int ArtistId { get; set; }
        [Required]
        public string ArtistName { get; set; }
        public string Description { get; set; }
        public IEnumerable<IdNameBase> OriginalSongs { get; set; }
        public IEnumerable<ShowDto> Shows { get; set; }

        public IEnumerable<SongPerformance> LiveSongs { get; set; }

    }
}
