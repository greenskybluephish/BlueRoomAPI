using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class LocaleDto
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public ICollection<VenueDto> Venues { get; set; }
    }
}
