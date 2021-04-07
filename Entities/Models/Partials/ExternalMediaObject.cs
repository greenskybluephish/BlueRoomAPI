using Entities.Models.Partials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ExternalMediaObject
    {
        [Key]
        [Column("ExternalMediaObjectId")]
        public int Id { get; set; }

        [Required] public string Description { get; set; }

        [Required] public string Url { get; set; }

        [Required] public MediaType Type { get; set; }

        public ICollection<SongPerformance> SongPerformances { get; set; }
        public ICollection<Show> Shows { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}