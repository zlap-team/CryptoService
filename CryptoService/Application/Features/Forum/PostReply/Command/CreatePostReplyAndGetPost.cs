using Application.Contracts.Repositories.Common;
using Application.Core;
using Application.DTOs.Forum.Post;
using Application.DTOs.Forum.PostReply;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Forum.PostReply.Command;

public class CreatePostReplyAndGetPost
{
    public class Command : IRequest<Result<PostDto>>
    {
        public string ParentPostId { get; set; }
        public CreatePostReplyDto PostReplyModel { get; set; }
    }
    
    public class Handler : IRequestHandler<Command, Result<PostDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public Handler(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }
        
        public async Task<Result<PostDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.PostRepository
                .GetWithIncludes(x => x.Id == Guid.Parse(request.ParentPostId));

            var user = await _userManager.FindByIdAsync(request.PostReplyModel.UserId.ToString());

            if (post == null || user == null) return Result<PostDto>.Failure("Post or User does not exist");

            var postReply = new Domain.Entities.PostReply
            {
                Id = Guid.NewGuid(),
                Message = request.PostReplyModel.Message,
                CreatedAt = DateTime.Now,

                PostId = post.Id,
                UserId = user.Id
            };

            post.AddReplyToPost(postReply);
            await _unitOfWork.PostReplyRepository.AddAsync(postReply);
            var result = await _unitOfWork.CompleteAsync() > 0;

            if (result)
            {
                var postUpdated = await _unitOfWork.PostRepository.GetWithIncludes(x => x.Id == post.Id);
                var postToReturn = _mapper.Map<Domain.Entities.Post, PostDto>(postUpdated);

                return Result<PostDto>.Success(postToReturn);
            }
                
            return Result<PostDto>.Failure("Problem with adding Reply to Post");
        }
    }
}