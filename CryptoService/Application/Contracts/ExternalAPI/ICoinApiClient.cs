using Domain.Models;

namespace Application.Contracts.ExternalAPI;

public interface ICoinApiClient : IDisposable
{
    Task<List<ExchangeExternalApi>> GetAllExchanges();
    Task<List<ExchangeIconExternalApi>> GetAllExchangesIcons(string iconSize);
}