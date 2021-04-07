using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IShowRepository : IRepositoryBase<Show>
    {
        Task<IEnumerable<Show>> GetShowsAsync(int artistId, bool trackChanges);
        Task<IEnumerable<Show>> GetAllShowsAsync(bool trackChanges);
        Task<Show> GetShowAsync(int showId, bool trackChanges);
        void CreateShow(Show show);
        Task<IEnumerable<Show>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
        void DeleteShow(Show show);
    }
}