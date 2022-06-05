using System.ComponentModel.DataAnnotations;
using Application.Contracts.ExternalAPI;
using Application.Core;
using Application.DTOs.NewsApi;
using AutoMapper;
using Domain.Models.News;
using MediatR;

namespace Application.Features.NewsApi.Query;

public class GetAllArticles
{
    public class Query : IRequest<Result<List<Article>>>
    {
        public string SearchParameter { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, Result<List<Article>>>
    {
        private readonly INewsApiClient _newsApiClient;
        private readonly IMapper _mapper;

        public Handler(INewsApiClient newsApiClient, IMapper mapper)
        {
            _newsApiClient = newsApiClient;
            _mapper = mapper;
        }
        
        public async Task<Result<List<Article>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var articles = await _newsApiClient.GetAllArticles(request.SearchParameter);

            var articlesToReturn = _mapper.Map<List<ArticleExternalApi>, List<Article>>(articles);

            return articlesToReturn.Count > 0
                ? Result<List<Article>>.Success(articlesToReturn)
                : Result<List<Article>>.Failure("Problem with fetching Articles");
        }
    }
}