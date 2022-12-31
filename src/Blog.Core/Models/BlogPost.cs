using Blog.Core.Models;
using System.Text.Json.Serialization;

public class BlogPost
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string? Header { get; set; }

    [JsonPropertyName("description")]
    public string? FeatureText { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }
}

