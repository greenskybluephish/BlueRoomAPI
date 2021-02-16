using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface ILocaleRepository : IRepositoryBase<Locale>
    {
        Task<IEnumerable<Locale>> GetAllLocalesAsync(bool trackChanges);
        Task<Locale> GetLocaleAsync(Guid localeId, bool trackChanges);
        void CreateLocale(Locale locale);
        Task<IEnumerable<Locale>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteLocale(Locale locale);
    }
}