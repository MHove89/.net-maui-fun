using Blog.Core.Models;

namespace Blog.Core.Services
{
    public interface IBlogService
    {
        Task<BlogPostsResponse?> GetBlogPostsAsync();
    }
}