using Application.Core;
using Application.DTOs.Account;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Account.Command;

public class RegisterUser
{
    public class Command : IRequest<Result<UserDto>>
    {
        public RegisterDto RegisterDto { get; set; }
    }

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.RegisterDto.Email).NotEmpty().WithMessage("Email address is required")
                .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")
                .WithMessage("A valid email is required");
            RuleFor(x => x.RegisterDto.Password).NotEmpty().MaximumLength(30)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()])(?!.*userName)(?!.*(.)\1{2,}).{6,}$")
                .WithMessage(
                    "Password must be at least 6 characters long, and must contain at least 1 Uppercase, 1 Lowercase, 1 Number, 1 special sign");
            RuleFor(x => x.RegisterDto.ConfirmPassword).Equal(p => p.RegisterDto.Password);
            RuleFor(x => x.RegisterDto.FirstName).NotEmpty().MaximumLength(50);
        }
    }
    
    public class Handler : IRequestHandler<Command, Result<UserDto>>
    {
        private readonly UserManager<AppUser> _userManager;

        public Handler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<Result<UserDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var validationResult = await new Validator().ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) return Result<UserDto>.Failure(validationResult);
            
            var userToCreate = new AppUser
            {
                Email = request.RegisterDto.Email,
                UserName = request.RegisterDto.Email,
                FirstName = request.RegisterDto.FirstName
            };

            var result = await _userManager.CreateAsync(userToCreate, request.RegisterDto.Password);
            if (!result.Succeeded) return Result<UserDto>.Failure(result.Errors.First().Description);

            var createdUser = await _userManager.FindByEmailAsync(request.RegisterDto.Email);
            if (createdUser == null) return Result<UserDto>.Failure("Failed to create new user...");

            var newUser = new UserDto
            {
                Email = createdUser.Email,
                FirstName = createdUser.FirstName
            };
            
            return Result<UserDto>.Success(newUser);
        }
    }
}