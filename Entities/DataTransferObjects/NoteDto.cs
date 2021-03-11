using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class NoteDto
    {
        public Guid Id { get; set; }

        [Required] public int Index { get; set; }

        [Required] public string Description { get; set; }
    }
}
