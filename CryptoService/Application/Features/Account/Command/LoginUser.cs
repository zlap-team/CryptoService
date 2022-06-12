using Application.Core;
using Application.DTOs.Account;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Account.Command;

public class LoginUser
{
    public class Command : IRequest<Result<UserDto>>
    {
        public LoginDto LoginDto { get; set; }
    }
    
    public class Handler : IRequestHandler<Command, Result<UserDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public Handler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public async Task<Result<UserDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.LoginDto.Email);

            if (user == null) return Result<UserDto>.Unauthorized($"User with {request.LoginDto.Email} email not found");

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.LoginDto.Password, false);

            if (!result.Succeeded) return Result<UserDto>.Unauthorized("Wrong password...");

            var userDto = new UserDto
            {
                Email = user.Email,
                FirstName = user.FirstName
            };
            
            return Result<UserDto>.Authorized(userDto);
        }
    }
}