using Application.Contracts.Repositories.Common;
using Application.Core;
using Application.DTOs.Forum.Post;
using AutoMapper;
using MediatR;

namespace Application.Features.Forum.Post.Query;

public class GetPost
{
    public class Query : IRequest<Result<PostDto>>
    {
        public string PostId { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, Result<PostDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Handler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<Result<PostDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.PostRepository.GetWithIncludes(x => x.Id == Guid.Parse(request.PostId));
            
            if (post == null) return Result<PostDto>.Failure("Post not found");
            
            var postToReturn = _mapper.Map<Domain.Entities.Post, PostDto>(post);

            return Result<PostDto>.Success(postToReturn);
        }
    }
}