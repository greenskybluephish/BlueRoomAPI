using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface ICommentRepository : IRepositoryBase<Comment>
    {
        Task<IEnumerable<Comment>> GetAllCommentsAsync(bool trackChanges);
        Task<Comment> GetCommentAsync(Guid commentId, bool trackChanges);
        void CreateComment(Comment comment);
        Task<IEnumerable<Comment>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteComment(Comment comment);
    }
}