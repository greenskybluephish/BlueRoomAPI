using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ExternalMediaObjectRepository : RepositoryBase<ExternalMediaObject>, IExternalMediaObjectRepository
    {
        public ExternalMediaObjectRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<ExternalMediaObject>> GetAllExternalMediaObjectsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.Type)
                .ToListAsync();

        public async Task<ExternalMediaObject> GetExternalMediaObjectAsync(Guid externalMediaObjectId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(externalMediaObjectId), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<ExternalMediaObject>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.Id), trackChanges)
                .ToListAsync();

        public void CreateExternalMediaObject(ExternalMediaObject externalMediaObject) => Create(externalMediaObject);

        public void DeleteExternalMediaObject(ExternalMediaObject externalMediaObject)
        {
            Delete(externalMediaObject);
        }
    }
}