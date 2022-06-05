using Application.Contracts.ExternalAPI;
using Domain.Models.News;
using RestSharp;

namespace Infrastructure.ExternalAPI.NewsAPI;

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

    public async Task<List<ArticleExternalApi>> GetAllArticles(string parameter)
    {
        var response = await _client
            .GetJsonAsync<NewsResponseExternalApi>($"/everything?q={parameter}");
        
        return response!.Articles;
    }

    // Methods
    
    // TODO NewsApi methods
    // TODO: Dodać kontrolery
    // TODO: Dodać modele
}