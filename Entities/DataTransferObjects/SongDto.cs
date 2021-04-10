using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SongDto
    {
        public int SongId { get; set; }

        [Required] public string Name { get; set; }

        public string Description { get; set; }

        [Required] public int OriginalArtistId { get; set; }

        public ArtistDto OriginalArtist { get; set; }

        public ICollection<SongPerformanceDto> SongPerformances { get; set; }


    }

    public class SongBase
    {
        public SongBase(int id, string name)
        {
            Name = name;
            Id = id;
        }
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
