using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ShowDto
    {
        public ShowDto()
        {

        }
        public ShowDto(Show s)
        {
            ShowId = s.ShowId;
            ShowDate = s.Date;
            VenueName = s.Venue.Name;
            VenueCity = s.Venue.City;
            VenueState = s.Venue.State;
            VenueCountry = s.Venue.Country;
            ShowDateString = s.Date.ToShortDateString();
            ArtistId = s.PerformingArtistId;
            ArtistName = "";
            Setlist = new List<IdNameBase>();
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
/*        public ICollection<SongPerformanceDto> SongPerformances { get; set; }
        public ICollection<SongDto> Songs { get; set; }*/
        public IEnumerable<IdNameBase> Setlist { get; set; }

    }

}
