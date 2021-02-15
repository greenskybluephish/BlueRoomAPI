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
    public class SongPerformanceRepository : RepositoryBase<SongPerformance>, ISongPerformanceRepository
    {
        public SongPerformanceRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<SongPerformance>> GetAllSongPerformancesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .ToListAsync();

        public async Task<SongPerformance> GetSongPerformanceAsync(Guid songPerformanceId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(songPerformanceId), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<SongPerformance>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.Id), trackChanges)
                .ToListAsync();

        public void CreateSongPerformance(SongPerformance songPerformance) => Create(songPerformance);

        public void DeleteSongPerformance(SongPerformance songPerformance)
        {
            Delete(songPerformance);
        }
    }
}