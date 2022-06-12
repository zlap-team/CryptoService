using Domain.Models.CoinGecko;

namespace Application.Contracts.ExternalAPI;

public interface ICoinGeckoApiClient : IDisposable
{
    Task<List<MarketExternalApi>> GetAllMarkets(string currencyParameter);
}