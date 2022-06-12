using Application.Contracts.Repositories.Specific;
using Domain.Entities;
using Persistence.Repositories.Common;

namespace Persistence.Repositories.Specific;

public class PostReplyRepository : BaseRepository<PostReply>, IPostReplyRepository
{
    private readonly CryptoDbContext _context;

    public PostReplyRepository(CryptoDbContext context) : base(context)
    {
        _context = context;
    }
}