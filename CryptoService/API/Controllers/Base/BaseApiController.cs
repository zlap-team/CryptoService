using Application.Contracts.ExternalAPI;
using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Base;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

    private ICoinApiClient _coinApiClient;

    protected ICoinApiClient CoinApiClient => _coinApiClient ??= HttpContext.RequestServices
        .GetService<ICoinApiClient>();

    protected ActionResult HandleResult<T>(Result<T> result)
    {
        if (result == null)
            return NotFound();
        if (result.IsSuccess && result.Value != null)
            return Ok(result.Value);
        if (result.IsSuccess && result.Value == null)
            return NotFound();
        if (result.IsAuthorized == true && result.Value != null)
            return Ok(result.Value);
        if (result.IsAuthorized == false && result.Value == null)
            return Unauthorized(result.Error);
        if (!result.IsSuccess && !string.IsNullOrEmpty(result.Error))
            return BadRequest(result.Error);
        return BadRequest(result.Error);
    }
}