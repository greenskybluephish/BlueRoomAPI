using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("note")]
    public class Note
    {
        [Key] [Column("NoteId")] public Guid Id { get; set; }

        [Required] public int Index { get; set; }

        [Required] public string Description { get; set; }

        public ICollection<SongPerformance> SongPerformancess { get; set; }
        public ICollection<Show> Shows { get; set; }
    }
}