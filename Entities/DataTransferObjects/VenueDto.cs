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
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        public string Description { get; set; }

        [Required] public int LocaleId { get; set; }

        public LocaleDto Location { get; set; }
        public ICollection<ShowDto> Shows { get; set; }
    }
}
