using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface INoteRepository : IRepositoryBase<Note>
    {
        Task<IEnumerable<Note>> GetAllNotesAsync(bool trackChanges);
        Task<Note> GetNoteAsync(Guid noteId, bool trackChanges);
        void CreateNote(Note note);
        Task<IEnumerable<Note>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteNote(Note note);
    }
}