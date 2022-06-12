using System.Linq.Expressions;
using Application.Contracts.Repositories.Common;
using Domain.Entities;

namespace Application.Contracts.Repositories.Specific;

public interface IPostRepository : IBaseRepository<Post>
{
    Task<List<Post>> GetAllPostsWithIncludes();
    Task<Post> GetWithIncludes(Expression<Func<Post, bool>> criteria);
}