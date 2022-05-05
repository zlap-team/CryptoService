using API.Controllers.Base;
using Application.DTOs.Account;
using Application.Features.Account.Command;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AccountController : BaseApiController
{
    /// <summary>
    /// Login existing user
    /// </summary>
    /// <param name="loginDto">Login form values</param>
    /// <returns>New user object with basic information</returns>
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> LoginUser([FromBody] LoginDto loginDto)
    {
        var result = await Mediator.Send(new LoginUser.Command {LoginDto = loginDto});

        return HandleResult(result);
    }

    /// <summary>
    /// Register new user
    /// </summary>
    /// <param name="registerDto">User data obtained from the register form</param>
    /// <returns>New user object with basic information</returns>
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> RegisterUser([FromBody] RegisterDto registerDto)
    {
        var result = await Mediator.Send(new RegisterUser.Command {RegisterDto = registerDto});

        return HandleResult(result);
    }
}