using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface ISongPerformanceRepository
    {
        Task<IEnumerable<SongPerformance>> GetAllSongPerformancesAsync(bool trackChanges);
        Task<SongPerformance> GetSongPerformanceAsync(Guid songPerformanceId, bool trackChanges);
        void CreateSongPerformance(SongPerformance songPerformance);
        Task<IEnumerable<SongPerformance>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteSongPerformance(SongPerformance songPerformance);
    }
}