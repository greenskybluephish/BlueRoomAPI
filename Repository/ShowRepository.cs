using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ShowRepository : RepositoryBase<Show>, IShowRepository
    {
        public ShowRepository(BlueRoomContext repositoryContext)
            : base(repositoryContext)
        {
        }

            public async Task<IEnumerable<Show>> GetAllShowsAsync(bool trackChanges) =>
                 await FindAll(trackChanges)
                     .Include(s=>s.SongPerformances).Include(a=>a.PerformingArtist)
            .OrderBy(c => c.Date)
            .ToListAsync();

        public async Task<IEnumerable<Show>> GetShowsAsync(int artistId, bool trackChanges) =>
            await FindByCondition(s => s.PerformingArtistId.Equals(artistId), trackChanges)
                .OrderByDescending(c => c.Date)
                .ToListAsync();

        public async Task<Show> GetShowAsync(int showId, bool trackChanges) =>
            await FindByCondition(c => c.ShowId.Equals(showId), trackChanges)
            .Include(s=>s.SongPerformances)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Show>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.ShowId), trackChanges)
                .ToListAsync();

        public void CreateShow(Show show) => Create(show);

        public void DeleteShow(Show show)
        {
            Delete(show);
        }
    }
}