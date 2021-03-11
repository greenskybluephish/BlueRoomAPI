using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("setlist")]
    public class Setlist : IEntity
    {
        [Key] [Column("SetlistId")] public Guid Id { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }

        [Required] public Guid VenueId { get; set; }

        public Venue Venue { get; set; }

        [Required(ErrorMessage = "Artist Id is required")]
        public Guid PerformingArtistId { get; set; }

        public Artist PerformingArtist { get; set; }
        public ICollection<SongPerformance> SongPerformances { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<ExternalMediaObject> ExternalMediaObjects { get; set; }
    }
}