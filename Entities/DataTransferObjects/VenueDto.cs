using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class VenueDto
    {
        public int VenueId { get; set; }

        [Required] public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string City { get; set; }
        [Required]
        [StringLength(55)]
        public string State { get; set; }

        [StringLength(55)]
        public string Country { get; set; }
        public ICollection<ShowDto> Shows { get; set; }
    }
}
