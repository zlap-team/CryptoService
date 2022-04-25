using API.Controllers.Base;
using Application.DTOs.NewsApi;
using Application.Features.NewsApi.Query;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class NewsApiController : BaseApiController
{
    [HttpGet("{searchParam}")]
    public async Task<ActionResult<List<Article>>> GetArticles([FromRoute] string searchParam)
    {
        var result = await Mediator.Send(new GetAllArticles.Query {SearchParameter = searchParam});

        return HandleResult(result);
    }
    
    [HttpGet("crypto")]
    public async Task<ActionResult<List<Article>>> GetCryptoArticles()
    {
        var result = await Mediator.Send(new GetAllArticles.Query {SearchParameter = "crypto"});

        return HandleResult(result);
    }
    
    [HttpGet("bank")]
    public async Task<ActionResult<List<Article>>> GetBankArticles()
    {
        var result = await Mediator.Send(new GetAllArticles.Query {SearchParameter = "bank"});

        return HandleResult(result);
    }
    
    [HttpGet("economy")]
    public async Task<ActionResult<List<Article>>> GetEconomyArticles()
    {
        var result = await Mediator.Send(new GetAllArticles.Query {SearchParameter = "economy"});

        return HandleResult(result);
    }
}