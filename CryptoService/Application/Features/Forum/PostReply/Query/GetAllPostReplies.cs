using Application.Contracts.Repositories.Common;
using Application.Core;
using Application.DTOs.Forum.PostReply;
using AutoMapper;
using MediatR;

namespace Application.Features.Forum.PostReply.Query;

public class GetAllPostReplies
{
    public class Query : IRequest<Result<List<PostReplyDto>>>
    {
        public string PostId { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<List<PostReplyDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Handler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<PostReplyDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var doesPostExists = await _unitOfWork.PostRepository
                .CheckIfExistsAsync(x => x.Id == Guid.Parse(request.PostId));

            if (!doesPostExists) return Result<List<PostReplyDto>>.Failure("Post does not exist");

            var postReplies = await _unitOfWork.PostReplyRepository
                .GetAllAsyncWithCriteria(x => x.ParentPostId == Guid.Parse(request.PostId));

            var repliesToReturn = _mapper.Map<List<Domain.Entities.PostReply>, List<PostReplyDto>>(postReplies);
            
            return Result<List<PostReplyDto>>.Success(repliesToReturn);
        }
    }
}