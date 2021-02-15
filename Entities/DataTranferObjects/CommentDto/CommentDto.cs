using System;

namespace Entities.DataTranferObjects.CommentDto
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid AuthorId { get; set; }
        public string Text { get; set; }
    }
}