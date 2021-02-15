using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("comment")]
    public class Comment
    {
        [Key] [Column("CommentId")] public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; }

        [Required] public Guid AuthorId { get; set; }

        [Required] public string Text { get; set; }

        [Required] public Guid SetlistId { get; set; }

        public Setlist Setlist { get; set; }
    }
}