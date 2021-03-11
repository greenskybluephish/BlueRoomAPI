using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class VenueDto
    {
        [Key]
        [Column("VenueId")]
        public Guid Id { get; set; }

        [Required] public string Name { get; set; }

        public string Description { get; set; }

        [Required] public Guid LocaleId { get; set; }

        public LocaleDto Location { get; set; }
        public ICollection<SetlistDto> Setlists { get; set; }
    }
}
