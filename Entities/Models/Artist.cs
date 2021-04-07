using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Artist : IEntity
    {
        [Key] [Column("ArtistId")] public int Id { get; set; }

        [Required] public string Name { get; set; }

        public string Description { get; set; }
        public ICollection<Song> OriginalSongs { get; set; }
        public ICollection<Show> Shows { get; set; }
        public ICollection<ExternalMediaObject> ExternalMediaObjects { get; set; }
        [NotMapped]
        public IEnumerable<SongPerformance> SongPerformances { get;set;}
    }
}