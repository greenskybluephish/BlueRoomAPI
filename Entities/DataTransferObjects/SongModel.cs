using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SongModel
    {
        public Guid Id { get; set; }

        [Required] public string Name { get; set; }

        public string Description { get; set; }

        [Required] public Guid OriginalArtistId { get; set; }

        public ArtistModel OriginalArtist { get; set; }
        public ICollection<ExternalMediaObjectModel> ExternalMediaObjects { get; set; }
        public ICollection<SongPerformanceModel> SongPerformances { get; set; }
    }
}
