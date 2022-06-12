using System.Text.Json.Serialization;

namespace Domain.Models.CoinGecko;

public class MarketExternalApi
{
    [JsonPropertyName("id")] 
    public string Id { get; set; }

    [JsonPropertyName("symbol")] 
    public string Symbol { get; set; }

    [JsonPropertyName("name")] 
    public string Name { get; set; }

    [JsonPropertyName("image")] 
    public string Image { get; set; }

    [JsonPropertyName("current_price")] 
    public double CurrentPrice { get; set; }

    [JsonPropertyName("high_24h")] 
    public double High24h { get; set; }

    [JsonPropertyName("low_24h")] 
    public double Low24h { get; set; }

    [JsonPropertyName("price_change_24h")] 
    public double PriceChange24h { get; set; }

    [JsonPropertyName("price_change_percentage_24h")]
    public double PriceChangePercentage24h { get; set; }

    [JsonPropertyName("last_updated")] 
    public DateTime LastUpdated { get; set; }
}