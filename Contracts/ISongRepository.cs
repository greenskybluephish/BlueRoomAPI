using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface ISongRepository : IRepositoryBase<Song>
    {
        Task<IEnumerable<Song>> GetAllSongsAsync(bool trackChanges);
        Task<Song> GetSongAsync(int songId, bool trackChanges);
        void CreateSong(Song song);
        Task<IEnumerable<Song>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
        void DeleteSong(Song song);
    }
}