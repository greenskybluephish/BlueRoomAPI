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
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(c => c.Timestamp)
                .ToListAsync();

        public async Task<Comment> GetCommentAsync(Guid commentId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(commentId), trackChanges)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<Comment>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.Id), trackChanges)
                .ToListAsync();

        public void CreateComment(Comment comment) => Create(comment);

        public void DeleteComment(Comment comment)
        {
            Delete(comment);
        }
    }
}