using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("locale")]
    public class Locale
    {
        [Key] [Column("LocaleId")] public Guid Id { get; set; }

        [Required] public string City { get; set; }

        [Required] public string State { get; set; }

        [Required] public string Country { get; set; }

        public ICollection<Venue> Venues { get; set; }
    }
}