using API.Controllers.Base;
using Application.Features.CoinGecko.Query;
using Domain.Models;
using Domain.Models.CoinGecko;
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
    public async Task<ActionResult<List<ExchangeExternalApi>>> GetAllMarkets([FromRoute] string currency)
    {
        var result = await Mediator.Send(new GetMarkets.Query {CurrencyParameter = currency});

        return HandleResult(result);
    }
    
    /// <summary>
    /// Get single crypto details
    /// </summary>
    /// <param name="cryptoId">Id from list of markets</param>
    /// <returns></returns>
    [HttpGet("details/{cryptoId}")]
    public async Task<ActionResult<List<CryptoDetails>>> GetCryptoDetails([FromRoute] string cryptoId)
    {
        var result = await Mediator.Send(new GetCryptoDetails.Query {CryptoId = cryptoId});

        return HandleResult(result);
    }
}