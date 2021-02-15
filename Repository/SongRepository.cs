using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class SongRepository : RepositoryBase<Song>, ISongRepository
    {
        public SongRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Song>> GetAllSongsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .ToListAsync();

        public async Task<Song> GetSongAsync(Guid SongId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(SongId), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Song>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.Id), trackChanges)
                .ToListAsync();

        public void CreateSong(Song Song) => Create(Song);

        public void DeleteSong(Song Song)
        {
            Delete(Song);
        }
    }
}
