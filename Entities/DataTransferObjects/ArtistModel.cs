using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ArtistModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Song> Songs { get; set; }
        public ICollection<Setlist> SetLists { get; set; }
        public ICollection<ExternalMediaObject> ExternalMediaObjects { get; set; }
    }
}
