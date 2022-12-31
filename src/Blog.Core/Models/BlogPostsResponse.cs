using System.Text.Json.Serialization;

namespace Blog.Core.Models
{
    public class BlogPostsResponse
    {
        [JsonPropertyName("products")]
        public List<BlogPost>? BlogPosts { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
