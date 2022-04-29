using System.Linq.Expressions;
using Application.Contracts.Repositories.Common;
using Domain.Entities;

namespace Application.Contracts.Repositories.Specific;

public interface IPostReplyRepository : IBaseRepository<PostReply>
{
    Task<List<PostReply>> GetAllRepliesWithIncludes(Expression<Func<PostReply, bool>> criteria);
}