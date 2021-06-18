using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class SongRepository : RepositoryBase<Song>, ISongRepository
    {
        public SongRepository(BlueRoomContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Song>> GetAllSongsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .ToListAsync();

        public async Task<Song> GetSongAsync(int songId, bool trackChanges) =>
            await FindByCondition(c => c.SongId.Equals(songId), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Song>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.SongId), trackChanges)
                .ToListAsync();

        public void CreateSong(Song song) => Create(song);

        public void DeleteSong(Song song)
        {
            Delete(song);
        }
    }
}
