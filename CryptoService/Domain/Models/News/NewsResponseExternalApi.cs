using System.Text.Json.Serialization;

namespace Domain.Models.News;

public class NewsResponseExternalApi
{
    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("totalResults")]
    public int TotalResults { get; set; }

    [JsonPropertyName("articles")]
    public List<ArticleExternalApi> Articles { get; set; }
}