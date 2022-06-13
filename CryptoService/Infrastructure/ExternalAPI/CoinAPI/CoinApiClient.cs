using Application.Contracts.ExternalAPI;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Infrastructure.ExternalAPI.CoinAPI;

public class CoinApiClient : ICoinApiClient
{
    private readonly RestClient _client;

    public CoinApiClient(IConfiguration config)
    {
        var options = new RestClientOptions("https://rest.coinapi.io/v1");
        
        _client = new RestClient(options).AddDefaultHeader("X-CoinAPI-Key", config["CoinApiKey"]);
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