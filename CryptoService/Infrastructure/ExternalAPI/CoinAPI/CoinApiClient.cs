using Application.Contracts.ExternalAPI;
using Domain.Models;
using RestSharp;

namespace Infrastructure.ExternalAPI.CoinAPI;

public class CoinApiClient : ICoinApiClient
{
    private readonly RestClient _client;

    public CoinApiClient()
    {
        var options = new RestClientOptions("https://rest.coinapi.io/v1");

        _client = new RestClient(options).AddDefaultHeader("X-CoinAPI-Key", "48EE2539-FC00-4BF5-98B2-2902472BC302");
    }
    
    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
    
    // Methods
    
    public async Task<List<ExchangeExternalApi>> GetAllExchanges()
    {
        var response = await _client
            .GetJsonAsync<List<ExchangeExternalApi>>("/exchanges");

        return response!;
    }

    public async Task<List<ExchangeIconExternalApi>> GetAllExchangesIcons(string iconSize)
    {
        var response = await _client
            .GetJsonAsync<List<ExchangeIconExternalApi>>($"/exchanges/icons/{iconSize}");

        return response!;
    }
}