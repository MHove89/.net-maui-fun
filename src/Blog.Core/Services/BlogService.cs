using Blog.Core.Models;
using System.Net.Http.Json;
using System.Reflection.PortableExecutable;

namespace Blog.Core.Services
{
    public class BlogService : IBlogService
    {
        private readonly HttpClient _httpClient;
        private readonly BlogSettings _blogSettings;

        public BlogService(
            HttpClient httpClient,
            BlogSettings blogSettings)
        {
            _httpClient = httpClient;
            _blogSettings = blogSettings;
        }

        public async Task<BlogPostsResponse?> GetBlogPostsAsync()
        {
            var productResponse = await _httpClient.GetFromJsonAsync<BlogPostsResponse>(_blogSettings.BlogPostEndpoint);
            _httpClient.Dispose();

            return productResponse;
        }
    }
}
