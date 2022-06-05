using System.Text.Json.Serialization;

namespace Domain.Models.News;

public class SourceExternalApi
{
    [JsonPropertyName("id")] 
    public string Id { get; set; }

    [JsonPropertyName("name")] 
    public string Name { get; set; }
}