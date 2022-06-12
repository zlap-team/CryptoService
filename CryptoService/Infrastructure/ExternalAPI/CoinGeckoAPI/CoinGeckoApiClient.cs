using Application.Contracts.ExternalAPI;
using Domain.Models.CoinGecko;
using RestSharp;

namespace Infrastructure.ExternalAPI.CoinGeckoAPI;

public class CoinGeckoApiClient : ICoinGeckoApiClient
{
    private readonly RestClient _client;

    public CoinGeckoApiClient()
    {
        var options = new RestClientOptions("https://api.coingecko.com/api/v3/");

        _client = new RestClient(options);
    }
    
    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task<List<MarketExternalApi>> GetAllMarkets(string currencyParameter)
    {
        var response = await _client
            .GetJsonAsync<List<MarketExternalApi>>($"/coins/markets?vs_currency={currencyParameter}");
        
        return response!;
    }

    public async Task<CryptoDetails> GetCryptoDetails(string cryptoId)
    {
        var response = await _client
            .GetJsonAsync<CryptoDetails>($"/coins/{cryptoId}");
        
        return response!;
    }
}