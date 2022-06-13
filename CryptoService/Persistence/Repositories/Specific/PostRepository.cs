using System.Linq.Expressions;
using Application.Contracts.Repositories.Specific;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;

namespace Persistence.Repositories.Specific;

public class PostRepository : BaseRepository<Post>, IPostRepository
{
    private readonly CryptoDbContext _context;

    public PostRepository(CryptoDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Post>> GetAllPostsWithIncludes()
    {
        var posts = await _context.Posts
            .Include(x => x.Creator)
            .Include(x => x.PostReplies).ThenInclude(y => y.User)
            .ToListAsync();

        return posts;
    }

    public async Task<Post> GetWithIncludes(Expression<Func<Post, bool>> criteria)
    {
        var post = await _context.Posts
            .Include(x => x.Creator)
            .Include(x => x.PostReplies).ThenInclude(y => y.User)
            .FirstOrDefaultAsync(criteria);

        return post;
    }
}