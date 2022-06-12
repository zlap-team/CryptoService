using Application.Contracts.Repositories.Common;
using Application.Core;
using Application.DTOs.Forum.Post;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Forum.Post.Command;

public class CreatePost
{
    public class Command : IRequest<Result<Unit>>
    {
        public CreatePostDto PostModel { get; set; }
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
            var creator = await _userManager.FindByIdAsync(request.PostModel.CreatorId.ToString());

            if (creator == null) return Result<Unit>.Failure("User not found");
            
            var postToCreate = new Domain.Entities.Post
            {
                Id = Guid.NewGuid(),
                Title = request.PostModel.Title,
                Description = request.PostModel.Description,
                PostReplies = new List<Domain.Entities.PostReply>(),
                CreatedAt = DateTime.Now,

                CreatorId = request.PostModel.CreatorId,
                Creator = creator
            };

            await _unitOfWork.PostRepository.AddAsync(postToCreate);
            var result = await _unitOfWork.CompleteAsync() > 0;

            return result
                ? Result<Unit>.Success(Unit.Value)
                : Result<Unit>.Failure("Problem with creating new Post");
        }
    }
}