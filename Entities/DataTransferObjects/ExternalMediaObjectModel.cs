using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ExternalMediaObjectModel
    {
        [Key]
        [Column("CommentId")]
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public Guid SetlistId { get; set; }
    }
}
