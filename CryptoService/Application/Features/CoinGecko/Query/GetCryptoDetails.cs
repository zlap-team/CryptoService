using Application.Contracts.ExternalAPI;
using Application.Core;
using Domain.Models.CoinGecko;
using MediatR;

namespace Application.Features.CoinGecko.Query;

public class GetCryptoDetails
{
    public class Query : IRequest<Result<CryptoDetails>>
    {
        public string CryptoId { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<CryptoDetails>>
    {
        private readonly ICoinGeckoApiClient _coinGeckoApiClient;

        public Handler(ICoinGeckoApiClient coinGeckoApiClient)
        {
            _coinGeckoApiClient = coinGeckoApiClient;
        }

        public async Task<Result<CryptoDetails>> Handle(Query request,
            CancellationToken cancellationToken)
        {
            var cryptoDetails = await _coinGeckoApiClient.GetCryptoDetails(request.CryptoId);

            return cryptoDetails.Id != null
                ? Result<CryptoDetails>.Success(cryptoDetails)
                : Result<CryptoDetails>.Failure("Crypto with given ID not found");
        }
    }
}