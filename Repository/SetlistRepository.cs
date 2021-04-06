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
    public class SetlistRepository : RepositoryBase<Setlist>, ISetlistRepository
    {
        public SetlistRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Setlist>> GetSetlistsAsync(Guid artistId, bool trackChanges) =>
            await FindByCondition(s => s.PerformingArtistId.Equals(artistId), trackChanges)
                .OrderByDescending(c => c.Date)
                .ToListAsync();

        public async Task<Setlist> GetSetlistAsync(Guid setlistId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(setlistId), trackChanges)
            .Include(s=>s.SongPerformances)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Setlist>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.Id), trackChanges)
                .ToListAsync();

        public void CreateSetlist(Setlist setlist) => Create(setlist);

        public void DeleteSetlist(Setlist setlist)
        {
            Delete(setlist);
        }
    }
}