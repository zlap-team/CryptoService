using API.Controllers.Base;
using Application.Features.CoinApi.Query;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CoinApiController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<ExchangeExternalApi>>> GetExchanges()
    {
        var result = await Mediator.Send(new GetAllExchanges.Query());

        return HandleResult(result);
    }
    
    [HttpGet("icons/{iconSize:int}")]
    public async Task<ActionResult<List<ExchangeExternalApi>>> GetExchangesIcons([FromRoute] int iconSize)
    {
        var result = await Mediator.Send(new GetAllExchangesIcons.Query {IconSize = iconSize});

        return HandleResult(result);
    }
}