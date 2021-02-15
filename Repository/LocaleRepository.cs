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
    public class LocaleRepository : RepositoryBase<Locale>, ILocaleRepository
    {
        public LocaleRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Locale>> GetAllLocalesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.City)
                .ToListAsync();

        public async Task<Locale> GetLocaleAsync(Guid localeId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(localeId), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Locale>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.Id), trackChanges)
                .ToListAsync();

        public void CreateLocale(Locale locale) => Create(locale);

        public void DeleteLocale(Locale locale)
        {
            Delete(locale);
        }
    }
}