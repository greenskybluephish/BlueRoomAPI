using System;

namespace Entities.DataTranferObjects.NoteDto
{
    public class NoteDto
    {
        public Guid Id { get; set; }
        public int Index { get; set; }
        public string Description { get; set; }

    }
}