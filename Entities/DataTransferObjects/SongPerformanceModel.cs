using Entities.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SongPerformanceModel
    {
        [Key] [Column("SongPerformanceId")] public Guid Id { get; set; }

        [Required] public SetNumber SetIndex { get; set; }

        [Required] public int SetlistSongIndex { get; set; }

        public int? Duration { get; set; }
        public int? MediaLinkId { get; set; }
        public ExternalMediaObjectModel MediaLink { get; set; }

        [Required] public Guid SetlistId { get; set; }


        [Required] public Guid SongId { get; set; }

        [Required] public SongModel Song { get; set; }

        public ICollection<NoteModel> Notes { get; set; }
    }
}
