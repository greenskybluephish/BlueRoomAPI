using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Artist
    {
        [NotMapped]
        public IEnumerable<SongPerformance> SongPerformances { get; set; }
    }
}