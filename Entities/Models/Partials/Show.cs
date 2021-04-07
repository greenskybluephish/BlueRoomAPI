using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{

    public partial class Show
    {   
        [NotMapped]
        public ICollection<Song> Songs { get; set; }
    }
}