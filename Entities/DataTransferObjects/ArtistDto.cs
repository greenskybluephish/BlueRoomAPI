using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ArtistDto
    {
        public int ArtistId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<SongDto> Songs { get; set; }
        public ICollection<ShowDto> Shows { get; set; }

    }
}
