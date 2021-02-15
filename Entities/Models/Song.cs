using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("song")]
    public class Song
    {
        [Key] [Column("SongId")] public Guid Id { get; set; }

        [Required] public string Name { get; set; }

        public string Description { get; set; }

        [Required] public Guid OriginalArtistId { get; set; }

        public Artist OriginalArtist { get; set; }
        public ICollection<ExternalMediaObject> ExternalMediaObjects { get; set; }
        public ICollection<SongPerformance> SongPerformances { get; set; }
    }
}