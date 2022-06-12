using Application.Contracts.ExternalAPI;
using Application.Core;
using Application.DTOs.CoinGecko;
using AutoMapper;
using Domain.Models.CoinGecko;
using MediatR;

namespace Application.Features.CoinGecko.Query;

public class GetMarkets
{
    public class Query : IRequest<Result<List<MarketDto>>>
    {
        public string CurrencyParameter { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, Result<List<MarketDto>>>
    {
        private readonly ICoinGeckoApiClient _coinGeckoApiClient;
        private readonly IMapper _mapper;

        public Handler(ICoinGeckoApiClient coinGeckoApiClient, IMapper mapper)
        {
            _coinGeckoApiClient = coinGeckoApiClient;
            _mapper = mapper;
        }
        
        public async Task<Result<List<MarketDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var markets = await _coinGeckoApiClient.GetAllMarkets(request.CurrencyParameter);

            var marketsToReturn = _mapper.Map<List<MarketExternalApi>, List<MarketDto>>(markets);
            
            return marketsToReturn.Count > 0
                ? Result<List<MarketDto>>.Success(marketsToReturn)
                : Result<List<MarketDto>>.Failure("Problem with fetching Markets");
        }
    }
}