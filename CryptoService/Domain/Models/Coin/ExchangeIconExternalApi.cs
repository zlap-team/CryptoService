using System.Text.Json.Serialization;

namespace Domain.Models;

public class ExchangeIconExternalApi
{
    [JsonPropertyName("exchange_id")] 
    public string ExchangeId { get; set; }

    [JsonPropertyName("url")] 
    public string Url { get; set; }
}