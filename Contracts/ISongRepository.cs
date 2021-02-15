using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface ISongRepository
    {
        Task<IEnumerable<Song>> GetAllSongsAsync(bool trackChanges);
        Task<Song> GetSongAsync(Guid songId, bool trackChanges);
        void CreateSong(Song song);
        Task<IEnumerable<Song>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteSong(Song song);
    }
}