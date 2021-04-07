using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models
{
    public class SongPerformance : IEntity
    {
        [Key] [Column("SongPerformanceId")] public int Id { get; set; }

        [Required]
        public int SetNumberId { get; set; }

        public SetNumber SetNumber { get; set; }

        [Required] public int SetSongIndex { get; set; }

        public int? Duration { get; set; }
        public int? MediaLinkId { get; set; }
        public ExternalMediaObject MediaLink { get; set; }

        [Required] public int ShowId { get; set; }

        public Show Show { get; set; }

        public int SongId { get; set; }

        public Song Song { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}