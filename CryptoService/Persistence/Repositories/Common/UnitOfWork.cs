using Application.Contracts.Repositories.Common;
using Application.Contracts.Repositories.Specific;
using Persistence.Repositories.Specific;

namespace Persistence.Repositories.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly CryptoDbContext _context;
    private IPostRepository _postRepository;
    private IPostReplyRepository _postReplyRepository;

    public UnitOfWork(CryptoDbContext context)
    {
        _context = context;
    }
    
    public IPostRepository PostRepository =>
        _postRepository ?? new PostRepository(_context);
    public IPostReplyRepository PostReplyRepository =>
        _postReplyRepository ?? new PostReplyRepository(_context);

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}