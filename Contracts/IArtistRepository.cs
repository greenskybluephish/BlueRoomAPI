using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IArtistRepository
    {
        Task<IEnumerable<Artist>> GetAllArtistsAsync(bool trackChanges);
        Task<Artist> GetArtistAsync(Guid artistId, bool trackChanges);
        void CreateArtist(Artist artist);
        Task<IEnumerable<Artist>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteArtist(Artist artist);
    }
}