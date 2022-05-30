using Application.Contracts.ExternalAPI;
using RestSharp;

namespace Infrastructure.ExternalAPI.CoinAPI;

public class NewsApiClient : INewsApiClient
{
    private readonly RestClient _client;

    public NewsApiClient()
    {
        var options = new RestClientOptions("https://newsapi.org/v2");

        _client = new RestClient(options).AddDefaultHeader("X-Api-Key", "a3e2667b5c634b74bdc80328f58f1a94");
    }
    
    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
    
    // Methods
    
    // TODO NewsApi methods
    // TODO: Dodać kontrolery
    // TODO: Dodać modele
}