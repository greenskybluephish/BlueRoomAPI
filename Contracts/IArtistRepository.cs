using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;
using System.Collections;

namespace Contracts
{
    public interface IArtistRepository : IRepositoryBase<Artist>
    {
        Task<IEnumerable<Artist>> GetAllArtistsAsync(bool trackChanges);
        Task<Artist> GetArtistAsync(Guid artistId, bool trackChanges);
        Task<Artist> GetArtistWithSongsAsync(Guid artistId);
        void CreateArtist(Artist artist);

        void DeleteArtist(Artist artist);
    }
}
