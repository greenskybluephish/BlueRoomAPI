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
        public ShowDto()
        {

        }




        public int ShowId { get; set; }
        public DateTime ShowDate { get; set; }
        public string ShowDateString { get; set; }
        public string VenueName { get; set; }
        public string VenueCity { get; set; }
        public string VenueState { get; set; }
        public string VenueCountry { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public ICollection<SongPerformanceDto> SongPerformances { get; set; }
        public ICollection<SongDto> Songs { get; set; }
        public IEnumerable<IdNameBase> Setlist { get; set; }

    }
}
