using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SetlistModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }

        [Required] public Guid VenueId { get; set; }

        public Venue Venue { get; set; }

        [Required(ErrorMessage = "Artist Id is required")]
        public Guid PerformingArtistId { get; set; }

        public Artist PerformingArtist { get; set; }
        public ICollection<SongPerformanceModel> SongPerformances { get; set; }
        public ICollection<CommentModel> Comments { get; set; }
        public ICollection<NoteModel> Notes { get; set; }
        public ICollection<ExternalMediaObjectModel> ExternalMediaObjects { get; set; }
    }
}
