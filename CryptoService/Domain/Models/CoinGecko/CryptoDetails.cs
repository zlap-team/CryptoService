using System.Text.Json.Serialization;

namespace Domain.Models.CoinGecko;

public class CryptoDetails
{
    [JsonPropertyName("id")] public string Id { get; set; }
    [JsonPropertyName("symbol")] public string Symbol { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("block_time_in_minutes")]
    public int BlockTimeInMinutes { get; set; }

    [JsonPropertyName("hashing_algorithm")]
    public string HashingAlgorithm { get; set; }
    [JsonPropertyName("description")] public Description Description { get; set; }
    [JsonPropertyName("image")] public Image Image { get; set; }
    [JsonPropertyName("genesis_date")] public string GenesisDate { get; set; }

    [JsonPropertyName("sentiment_votes_up_percentage")]
    public double SentimentVotesUpPercentage { get; set; }

    [JsonPropertyName("sentiment_votes_down_percentage")]
    public double SentimentVotesDownPercentage { get; set; }

    [JsonPropertyName("market_data")] public MarketData MarketData { get; set; }
    [JsonPropertyName("last_updated")] public DateTime LastUpdated { get; set; }
}