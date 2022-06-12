using Application.Contracts.Repositories.Common;
using Application.Core;
using Application.DTOs.Forum.PostReply;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Forum.PostReply.Command;

public class CreatePostReply
{
    public class Command : IRequest<Result<Unit>>
    {
        public string ParentPostId { get; set; }
        public CreatePostReplyDto PostReplyModel { get; set; }
    }
    
    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        public Handler(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.PostRepository
                .GetWithIncludes(x => x.Id == Guid.Parse(request.ParentPostId));

            var user = await _userManager.FindByIdAsync(request.PostReplyModel.UserId.ToString());

            if (post == null || user == null) return Result<Unit>.Failure("Post or User does not exist");

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

            return result
                ? Result<Unit>.Success(Unit.Value)
                : Result<Unit>.Failure("Problem with adding Reply to Post");
        }
    }
}