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
}