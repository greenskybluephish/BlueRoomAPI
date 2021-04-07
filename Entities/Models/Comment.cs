using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Comment
    {
        [Key] [Column("CommentId")] public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; }

        [Required] public int AuthorId { get; set; }

        [Required] public string Text { get; set; }

        [Required] public int ShowId { get; set; }

        public Show Show { get; set; }
    }
}