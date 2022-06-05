using Domain.Models.News;

namespace Application.Contracts.ExternalAPI;

public interface INewsApiClient : IDisposable
{
    Task<List<ArticleExternalApi>> GetAllArticles(string parameter);
}