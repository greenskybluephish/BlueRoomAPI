using Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Context;
using Entities.Models;

namespace Repository
{
    public class ArtistRepository : RepositoryBase<Artist>, IArtistRepository
    {
        public ArtistRepository(BlueRoomContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .ToListAsync();

        public async Task<Artist> GetArtistAsync(int artistId, bool trackChanges) =>
            await FindByCondition(c => c.ArtistId.Equals(artistId), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<Artist> GetArtistWithSongsAsync(int artistId) =>
           await FindByCondition(c => c.ArtistId.Equals(artistId), false)
            .Include(a=>a.Songs)
               .SingleOrDefaultAsync();

        public async Task<IEnumerable<Artist>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.ArtistId), trackChanges)
                .ToListAsync();

        public void CreateArtist(Artist artist) => Create(artist);

        public void DeleteArtist(Artist artist)
        {
            Delete(artist);
        }
    }
}
