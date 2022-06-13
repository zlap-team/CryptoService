using Application.Contracts.Repositories.Common;
using Application.Core;
using Application.DTOs.Forum.Post;
using AutoMapper;
using MediatR;

namespace Application.Features.Forum.Post.Query;

public class GetAllPosts
{
    public class Query : IRequest<Result<List<PostDto>>>
    {
    }
    
    public class Handler : IRequestHandler<Query, Result<List<PostDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Handler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<Result<List<PostDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var posts = await _unitOfWork.PostRepository.GetAllPostsWithIncludes();
            var postsToReturn = _mapper.Map<List<Domain.Entities.Post>, List<PostDto>>(posts);
            
            return Result<List<PostDto>>.Success(postsToReturn);
        }
    }
}