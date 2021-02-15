using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class ArtistRepository : RepositoryBase<Artist>, IArtistRepository
    {
        public ArtistRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .ToListAsync();

        public async Task<Artist> GetArtistAsync(Guid artistId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(artistId), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Artist>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.Id), trackChanges)
                .ToListAsync();

        public void CreateArtist(Artist artist) => Create(artist);

        public void DeleteArtist(Artist artist)
        {
            Delete(artist);
        }
    }
}
