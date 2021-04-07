using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ArtistDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Song> Songs { get; set; }
        public ICollection<Show> Shows { get; set; }
        public ICollection<ExternalMediaObject> ExternalMediaObjects { get; set; }
    }
}
