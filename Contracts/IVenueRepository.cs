using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IVenueRepository : IRepositoryBase<Venue>
    {
        Task<IEnumerable<Venue>> GetAllVenuesAsync(bool trackChanges);
        Task<Venue> GetVenueAsync(Guid venueId, bool trackChanges);
        void CreateVenue(Venue venue);
        Task<IEnumerable<Venue>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteVenue(Venue venue);
    }
}