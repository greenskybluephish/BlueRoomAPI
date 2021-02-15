using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTranferObjects.CommentDto
{
    public abstract class CommentForManipulationDto
    {
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public string Text { get; set; }
    }
}