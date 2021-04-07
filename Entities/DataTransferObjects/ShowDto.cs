using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ShowDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }

        [Required] public int VenueId { get; set; }

        public Venue Venue { get; set; }

        [Required(ErrorMessage = "Artist Id is required")]
        public int PerformingArtistId { get; set; }

        public Artist PerformingArtist { get; set; }
        public ICollection<SongPerformanceDto> SongPerformances { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
        public ICollection<NoteDto> Notes { get; set; }
        public ICollection<ExternalMediaObjectDto> ExternalMediaObjects { get; set; }
    }
}
