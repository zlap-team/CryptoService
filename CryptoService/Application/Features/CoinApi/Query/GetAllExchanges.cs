using Application.Contracts.ExternalAPI;
using Application.Core;
using Application.DTOs.CoinApi;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.Features.CoinApi.Query;

public class GetAllExchanges
{
    public class Query : IRequest<Result<List<Exchange>>>
    {
    }

    public class Handler : IRequestHandler<Query, Result<List<Exchange>>>
    {
        private readonly ICoinApiClient _coinApiClient;
        private readonly IMapper _mapper;

        public Handler(ICoinApiClient coinApiClient, IMapper mapper)
        {
            _coinApiClient = coinApiClient;
            _mapper = mapper;
        }

        public async Task<Result<List<Exchange>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var exchanges = await _coinApiClient.GetAllExchanges();

            var exchangesToReturn = _mapper.Map<List<ExchangeExternalApi>, List<Exchange>>(exchanges);

            return exchangesToReturn.Count > 0
                ? Result<List<Exchange>>.Success(exchangesToReturn)
                : Result<List<Exchange>>.Failure("Problem with fetching Exchanges");
        }
    }
}