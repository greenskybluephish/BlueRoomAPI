using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Partials
{
    public class Locale
    {
        [Key] [Column("LocaleId")] public int Id { get; set; }

        [Required] public string City { get; set; }

        [Required] public string State { get; set; }

        [Required] public string Country { get; set; }

        public ICollection<Venue> Venues { get; set; }
    }
}