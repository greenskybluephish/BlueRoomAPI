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
        public int ShowId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }

        [Required] public int VenueId { get; set; }

        public VenueDto Venue { get; set; }

        [Required(ErrorMessage = "Artist Id is required")]
        public int PerformingArtistId { get; set; }
        public string PerformingArtistName { get; set; }
        public ICollection<SongPerformanceDto> SongPerformances { get; set; }
/*        public ICollection<SongDto> Songs { get; set; }*/

    }
}
