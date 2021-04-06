using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("external_media_object")]
    public class ExternalMediaObject
    {
        [Key]
        [Column("ExternalMediaObjectId")]
        public Guid Id { get; set; }

        [Required] public string Description { get; set; }

        [Required] public string Url { get; set; }

        [Required] public MediaType Type { get; set; }

        public ICollection<SongPerformance> SongPerformances { get; set; }
        public ICollection<Setlist> Setlists { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}