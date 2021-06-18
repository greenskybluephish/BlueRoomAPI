using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class VenueRepository : RepositoryBase<Venue>, IVenueRepository
    {
        public VenueRepository(BlueRoomContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Venue>> GetAllVenuesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .ToListAsync();

        public async Task<Venue> GetVenueAsync(int venueId, bool trackChanges) =>
            await FindByCondition(c => c.VenueId.Equals(venueId), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Venue>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.VenueId), trackChanges)
                .ToListAsync();

        public void CreateVenue(Venue venue) => Create(venue);

        public void DeleteVenue(Venue venue)
        {
            Delete(venue);
        }
    }
}