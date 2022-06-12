using Application.Contracts.Repositories.Specific;
using Domain.Entities;
using Persistence.Repositories.Common;

namespace Persistence.Repositories.Specific;

public class PostRepository : BaseRepository<Post>, IPostRepository
{
    private readonly CryptoDbContext _context;

    public PostRepository(CryptoDbContext context) : base(context)
    {
        _context = context;
    }
}