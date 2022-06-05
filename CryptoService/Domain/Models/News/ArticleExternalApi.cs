﻿using System.Text.Json.Serialization;

namespace Domain.Models.News;

public class ArticleExternalApi
{
    [JsonPropertyName("source")]
    public SourceExternalApi SourceExternalApi { get; set; }

    [JsonPropertyName("author")]
    public string Author { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("urlToImage")]
    public string UrlToImage { get; set; }

    [JsonPropertyName("publishedAt")]
    public DateTime PublishedAt { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }
}