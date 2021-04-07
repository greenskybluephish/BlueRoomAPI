using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections;
using Entities.Models.Partials;

namespace Contracts
{
    public interface IArtistRepository : IRepositoryBase<Artist>
    {
        Task<IEnumerable<Artist>> GetAllArtistsAsync(bool trackChanges);
        Task<Artist> GetArtistAsync(int artistId, bool trackChanges);
        Task<Artist> GetArtistWithSongsAsync(int artistId);
        void CreateArtist(Artist artist);

        void DeleteArtist(Artist artist);
    }
}
