using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Partials
{
    public class Venue
    {
        [Key]
        [Column("VenueId")]
        public int Id { get; set; }

        [Required] public string Name { get; set; }

        public string Description { get; set; }

        [Required] public int LocaleId { get; set; }

        public Locale Location { get; set; }
        public ICollection<Show> Shows { get; set; }
    }
}