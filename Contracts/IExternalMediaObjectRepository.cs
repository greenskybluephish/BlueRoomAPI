using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IExternalMediaObjectRepository
    {
        Task<IEnumerable<ExternalMediaObject>> GetAllExternalMediaObjectsAsync(bool trackChanges);
        Task<ExternalMediaObject> GetExternalMediaObjectAsync(Guid externalMediaObjectId, bool trackChanges);
        void CreateExternalMediaObject(ExternalMediaObject externalMediaObject);
        Task<IEnumerable<ExternalMediaObject>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteExternalMediaObject(ExternalMediaObject externalMediaObject);
    }
}