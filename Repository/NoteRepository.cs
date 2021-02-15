using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class NoteRepository : RepositoryBase<Note>, INoteRepository
    {
        public NoteRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Note>> GetAllNotesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.Index)
                .ToListAsync();

        public async Task<Note> GetNoteAsync(Guid noteId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(noteId), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Note>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.Id), trackChanges)
                .ToListAsync();

        public void CreateNote(Note note) => Create(note);

        public void DeleteNote(Note note)
        {
            Delete(note);
        }
    }
}