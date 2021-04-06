using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SongPerformanceDto
    {
        [Key] [Column("SongPerformanceId")] public Guid Id { get; set; }

        [Required] public SetNumber SetIndex { get; set; }

        [Required] public int ShowSongIndex { get; set; }

        public int? Duration { get; set; }
        public int? MediaLinkId { get; set; }
        public ExternalMediaObjectDto MediaLink { get; set; }

        [Required] public Guid ShowId { get; set; }


        [Required] public Guid SongId { get; set; }

        [Required] public SongDto Song { get; set; }

        public ICollection<NoteDto> Notes { get; set; }
    }
}
