﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface ISetlistRepository
    {
        Task<IEnumerable<Setlist>> GetAllSetlistsAsync(bool trackChanges);
        Task<Setlist> GetSetlistAsync(Guid setlistId, bool trackChanges);
        void CreateSetlist(Setlist setlist);
        Task<IEnumerable<Setlist>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteSetlist(Setlist setlist);
    }
}