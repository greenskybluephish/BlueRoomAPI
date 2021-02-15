using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("venue")]
    public class Venue
    {
        [Key] [Column("VenueId")] public Guid Id { get; set; }

        [Required] public string Name { get; set; }

        public string Description { get; set; }

        [Required] public Guid LocaleId { get; set; }

        public Locale Location { get; set; }
        public ICollection<Setlist> Setlists { get; set; }
    }
}