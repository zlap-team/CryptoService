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
            .Include(x => x.PostReplies)
            .ToListAsync();

        return posts;
    }
}