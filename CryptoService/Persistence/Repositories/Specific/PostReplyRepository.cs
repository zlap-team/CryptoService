using System.Linq.Expressions;
using Application.Contracts.Repositories.Specific;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Common;

namespace Persistence.Repositories.Specific;

public class PostReplyRepository : BaseRepository<PostReply>, IPostReplyRepository
{
    private readonly CryptoDbContext _context;

    public PostReplyRepository(CryptoDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<List<PostReply>> GetAllRepliesWithIncludes(Expression<Func<PostReply, bool>> criteria)
    {
        var postReplies = await _context.PostReplies
            .Include(x => x.User)
            .Where(criteria)
            .ToListAsync();

        return postReplies;
    }
}