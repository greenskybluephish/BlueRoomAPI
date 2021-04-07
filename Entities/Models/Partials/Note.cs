using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Partials
{
    public class Note
    {
        [Key] [Column("NoteId")] public int Id { get; set; }

        [Required] public int Index { get; set; }

        [Required] public string Description { get; set; }

        public ICollection<SongPerformance> SongPerformancess { get; set; }
        public ICollection<Show> Shows { get; set; }
    }
}