using Application.Contracts.Repositories.Specific;

namespace Application.Contracts.Repositories.Common;

public interface IUnitOfWork : IDisposable
{
    IPostRepository PostRepository { get; }
    IPostReplyRepository PostReplyRepository { get; }
    
    Task<int> CompleteAsync();
}