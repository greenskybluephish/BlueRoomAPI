using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IShowRepository : IRepositoryBase<Show>
    {
        Task<IEnumerable<Show>> GetShowsAsync(Guid artistId, bool trackChanges);
        Task<IEnumerable<Show>> GetAllShowsAsync(bool trackChanges);
        Task<Show> GetShowAsync(Guid showId, bool trackChanges);
        void CreateShow(Show show);
        Task<IEnumerable<Show>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteShow(Show show);
    }
}