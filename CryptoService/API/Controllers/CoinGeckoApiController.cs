using API.Controllers.Base;
using Application.Features.CoinGecko.Query;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CoinGeckoApiController : BaseApiController
{
    /// <summary>
    /// Get all markets with name, image, price, price statistics and price changes
    /// </summary>
    /// <param name="currency"></param>
    /// <returns></returns>
    [HttpGet("markets/{currency}")]
    public async Task<ActionResult<List<ExchangeExternalApi>>> GetExchangesIcons([FromRoute] string currency)
    {
        var result = await Mediator.Send(new GetMarkets.Query {CurrencyParameter = currency});

        return HandleResult(result);
    }
}