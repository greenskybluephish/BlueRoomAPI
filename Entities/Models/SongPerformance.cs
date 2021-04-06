using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models
{
    [Table("song_performance")]
    public class SongPerformance : IEntity
    {
        [Key] [Column("SongPerformanceId")] public Guid Id { get; set; }

        [Required]
        public Guid SetNumberId { get; set; }

         public SetNumber SetIndex { get; set; }

        [Required] public int ShowSongIndex { get; set; }

        public int? Duration { get; set; }
        public int? MediaLinkId { get; set; }
        public ExternalMediaObject MediaLink { get; set; }

        [Required] public Guid ShowId { get; set; }

        public Show Show { get; set; }

        [Required] public Guid SongId { get; set; }

        public Song Song { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}